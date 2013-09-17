using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var TCPSK = new Socket(IPAddress.Parse("192.168.0.93").AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            TCPSK.Connect(new IPEndPoint(IPAddress.Parse("192.168.0.93"), 8021));
            TCPSK.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 0);
            TCPSK.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);
            TCPSK.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, 1);
            while (true)
            {
                var k = Console.ReadLine();
                k = Guid.NewGuid().ToString() + " " + k;

                var tempg = Encoding.UTF8.GetBytes(k);
                var temp = BitConverter.GetBytes(tempg.Length);
                var sendlist = new List<byte>();

                sendlist.AddRange(temp);
                sendlist.AddRange(tempg);
                TCPSK.Send(sendlist.ToArray());

                var rclength = new byte[4];

                TCPSK.Receive(rclength);

                var length = BitConverter.ToInt32(rclength, 0);

                var rece = new byte[length];
                TCPSK.Receive(rece);

                Console.WriteLine(Encoding.UTF8.GetString(rece));
            }
        }
    }
}
