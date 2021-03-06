﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace LANTalk.Core
{
    public class Server
    {
        private Socket _socket;
        public IPAddress _ip;
        private int _port;
        
        public delegate void SocketAcceptCallback(Socket socketor);
        public delegate void ReceiveCallback(IPAddress ip, string content);
        public delegate string SendBefore(Socket socketor);
        public delegate void SocketLostCallback(Socket socketor);
        public delegate void ListenCallback();
        public delegate void ListenErrorCallback(Exception ex);

        private ReceiveCallback _receivecallback;
        private SocketAcceptCallback _socketaccpetcallback;
        private SendBefore _sendBefore;
        private ListenCallback _listenCallback;
        private ListenErrorCallback _listenErrorCallback;
        private SocketLostCallback _socketLostCallback;


        public void StartServer(IPAddress ip, int port, SocketAcceptCallback socketaccept = null, SocketLostCallback socketLost = null,ListenErrorCallback listenError=null, ReceiveCallback receive = null, SendBefore send = null, ListenCallback listen = null)
        {
            _ip = ip;
            _port = port;
            _socketaccpetcallback = socketaccept;
            _socketLostCallback = socketLost;
            _receivecallback = receive;
            _sendBefore = send;
            _listenCallback = listen;
            _listenErrorCallback = listenError;

            var listenThread = new Thread(Listen);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        public void StopServer()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
                _socket = null;
            }
        }

        private void Listen()
        {
            try
            {
                StopServer();

                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //设定接收超时
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
                //设定发送超时
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 3000);
                var ip = new IPEndPoint(_ip, _port);
                _socket.Bind(ip);
                _socket.Listen(0);
                if (_listenCallback != null)
                {
                    _listenCallback();
                }

                //开启线程 监控连接
                while (true)
                {
                    var temp = _socket.Accept();
                    //为新建连接创建新的Socket。
                    if (_socketaccpetcallback != null)
                    {
                        _socketaccpetcallback(temp);
                    }

                    var parStart = new ParameterizedThreadStart(Recieve);
                    var recieveThread = new Thread(parStart);
                    recieveThread.IsBackground = true;
                    object o = temp;
                    recieveThread.Start(o);
                    if (_sendBefore != null)
                    {
                        parStart = new ParameterizedThreadStart(Send);
                        var sendThread = new Thread(parStart);
                        sendThread.IsBackground = true;
                        sendThread.Start(o);
                    }
                }
            }
            catch (Exception ex)
            {
                if (_socket != null)
                {
                    lock (_socket)
                    {
                        _socket.Close();
                        _socket.Dispose();
                        _socket = null;

                        if (_listenErrorCallback != null)
                        {
                            _listenErrorCallback(ex);
                        }
                    }
                }
            }
        }

        private void Recieve(object parObject)
        {
            var newSocket = (Socket)parObject;
            IPEndPoint clientipe = (IPEndPoint)newSocket.RemoteEndPoint;
            while (true)
            {
                try
                {
                    if (!newSocket.Connected)
                    {
                        break;
                    }
                    var recByte = new byte[4];
                    newSocket.Receive(recByte);

                    var length = BitConverter.ToInt32(recByte, 0);
                    recByte = new byte[length];
                    int flag = 0;
                    while (flag < recByte.Length)
                    {
                        flag += newSocket.Receive(recByte, flag, recByte.Length - flag, SocketFlags.None);
                    }

                    var recString = Encoding.UTF8.GetString(recByte);
                    if (_receivecallback != null)
                    {
                        _receivecallback(clientipe.Address, recString);
                    }
                }
                catch (Exception ex)
                {
                    if (newSocket != null)
                    {
                        lock (newSocket)
                        {
                            if (_socketLostCallback != null)
                            {
                                _socketLostCallback(newSocket);
                            }
                            newSocket.Disconnect(false);
                        }
                    }
                }
            }
        }

        private void Send(object parObject)
        {
            var newSocket = (Socket)parObject;
            while (true)
            {
                try
                {
                    if (!newSocket.Connected)
                    {
                        break;
                    }
                    if (_sendBefore != null)
                    {
                        var sendString = _sendBefore(newSocket);
                        if (sendString.Length > 0)
                        {
                            var sendContent = Encoding.UTF8.GetBytes(sendString);
                            var sendByte = new List<byte>();
                            sendByte.AddRange(BitConverter.GetBytes(sendContent.Length));
                            sendByte.AddRange(sendContent);
                            newSocket.Send(sendByte.ToArray());
                        }
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }

        public void CustomSend(Socket socket, string content)
        {
            var parStart = new ParameterizedThreadStart(SendContent);
            var recieveThread = new Thread(parStart);
            recieveThread.IsBackground = true;
            var temp = new List<object>();
            temp.Add(socket);
            temp.Add(content);
            object o = temp;
            
            recieveThread.Start(o);
        }

        private void SendContent(object o)
        {
            var par = (List<object>)o;
            var socket = (Socket)par[0];
            var content = (string)par[1];
            try
            {

                if (!socket.Connected)
                {
                    return;
                }
                var tempg = Encoding.UTF8.GetBytes(content);
                var temp = BitConverter.GetBytes(tempg.Length);
                var sendlist = new List<byte>();

                sendlist.AddRange(temp);
                sendlist.AddRange(tempg);
                socket.Send(sendlist.ToArray());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
