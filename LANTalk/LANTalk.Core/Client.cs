using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace LANTalk.Core
{
    public class Client
    {
        private Socket _socket;
        private IPAddress _ip;
        private int _port;

        public IPAddress ClientIP;

        public delegate void ReceiveCallback(IPAddress ip, string content);
        public delegate void ConnectCallback();
        public delegate string SendBefore();
        public delegate void ErrorCallback(Exception ex);


        private ConnectCallback _connectcallback;
        private ReceiveCallback _receivecallback;
        private SendBefore _sendBefore;
        private ErrorCallback _errorCallback;

        public void ConnectServer(IPAddress ip, int port,ConnectCallback connect = null, ReceiveCallback receive = null, SendBefore send = null, ErrorCallback error = null)
        {
            if (_socket != null)
            {
                if (_socket.Connected == true)
                {
                    return;
                }
            }
            _ip = ip;
            _port = port;
            _connectcallback = connect;
            _receivecallback = receive;
            _sendBefore = send;
            _errorCallback = error;


            var listenThread = new Thread(Connect);
            listenThread.IsBackground = true;
            listenThread.Start();
        }



        public void DisConnect()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
                _socket = null;
            }
        }

        private void Connect()
        {
            try
            {
                DisConnect();

                _socket = new Socket(_ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 0);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);
                _socket.Connect(new IPEndPoint(_ip, _port));

                IPEndPoint clientipe = (IPEndPoint)_socket.LocalEndPoint;
                ClientIP = clientipe.Address;
                if (_connectcallback != null)
                {
                    _connectcallback();
                }
                if (_sendBefore != null)
                {
                    var sendThread = new Thread(Send);
                    sendThread.IsBackground = true;
                    sendThread.Start();
                }



                //开启线程 监控连接
                while (true)
                {
                    try
                    {
                        var rclength = new byte[4];
                        _socket.Receive(rclength);

                        var length = BitConverter.ToInt32(rclength, 0);

                        var rece = new byte[length];
                        _socket.Receive(rece);

                        if (_receivecallback != null)
                        {
                            _receivecallback(((IPEndPoint)_socket.LocalEndPoint).Address, Encoding.UTF8.GetString(rece));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (_socket != null)
                        {
                            lock (_socket)
                            {
                                if (_errorCallback != null)
                                {
                                    _errorCallback(ex);
                                }
                                _socket.Close();
                                _socket.Dispose();
                                _socket = null;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Send()
        {
            try
            {
                while (true)
                {
                    if (!_socket.Connected)
                    {
                        break;
                    }
                    if (_sendBefore != null)
                    {
                        var sendString = _sendBefore();
                        if (sendString.Length > 0)
                        {
                            var sendContent = Encoding.UTF8.GetBytes(sendString);
                            var sendByte = new List<byte>();
                            sendByte.AddRange(BitConverter.GetBytes(sendContent.Length));
                            sendByte.AddRange(sendContent);
                            _socket.Send(sendByte.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (_socket != null)
                {
                    lock (_socket)
                    {
                        if (_errorCallback != null)
                        {
                            _errorCallback(ex);
                        }
                        _socket.Close();
                        _socket.Dispose();
                        _socket = null;

                    }
                }
            }
        }

        public void SendContent(string content)
        {
            try
            {
                if (!_socket.Connected)
                {
                    return;
                }


                var tempg = Encoding.UTF8.GetBytes(content);
                var temp = BitConverter.GetBytes(tempg.Length);
                var sendlist = new List<byte>();

                sendlist.AddRange(temp);
                sendlist.AddRange(tempg);
                _socket.Send(sendlist.ToArray());
            }
            catch (Exception ex)
            {
                if (_socket != null)
                {
                    lock (_socket)
                    {
                        if (_errorCallback != null)
                        {
                            _errorCallback(ex);
                        }
                        _socket.Close();
                        _socket.Dispose();
                        _socket = null;
                    }
                }
            }
        }
    }

}
