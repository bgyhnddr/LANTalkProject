﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LANTalk.Core;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace LANTalk
{
    public partial class Server : Form
    {
        enum SendMode
        {
            send,
            request
        }

        private IPAddress _ip;
        private int _port;
        private StringBuilder _message;

        private LANTalk LANTalkForm;

        public Server(IPAddress ip,int port,LANTalk form)
        {
            _ip = ip;
            _port = port;
            Global.OnLineUserList = new List<OnlineUser>();
            _message = new StringBuilder();
            LANTalkForm = form;
            InitializeComponent();
        }



        private void Server_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            clbOnlineList.Items.Add("All/None");
            var server = new Core.Server();
            server.StartServer(
                _ip,
                _port,
                SocketAcceptCallback,
                SocketLostCallback,
                ListenErrorCallback,
                ReceiveCallback,
                SendBefore,
                ListenCallback
                );
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                return;
            }
        }

        private void Server_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                try
                {
                    this.Hide();    //隐藏窗口
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void OnlineChange()
        {
            lock (Global.OnLineUserList)
            {
                clbOnlineList.Items.Clear();
                clbOnlineList.Items.Add("All/None");
                foreach (var user in Global.OnLineUserList)
                {
                    clbOnlineList.Items.Add(user.IP.ToString() + (user.Name == string.Empty ? "" : "(" + user.Name + ")"));
                }
            }
        }

        private void WriteToAccess(string from, string to, string content)
        {
        }

        private void WriteMessage(string content)
        {
            _message.AppendLine(content);
            tbInfo.Text = _message.ToString();
        }

        
        
        private string SendBefore(IPAddress ip)
        {
            var returnString = string.Empty;
            lock (Global.OnLineUserList)
            {
                if (Global.OnLineUserList.Count > 0)
                {
                    var user = Global.OnLineUserList.Where(o => o.IP.Equals(ip)).First();
                    returnString = user.GetFirstSendContent();
                }
            }
            return returnString;
        }

        private void SocketAcceptCallback(IPAddress ip)
        {
            var User = new OnlineUser(ip);
            lock (Global.OnLineUserList)
            {
                Global.OnLineUserList.Add(User);
                OnlineChange();
            }
            _message.AppendLine(ip.ToString() + " online");
            tbInfo.Text = _message.ToString();
        }

        private void SocketLostCallback(IPAddress ip)
        {
            lock (Global.OnLineUserList)
            {
                var temp = from row in Global.OnLineUserList
                           where row.IP.Equals(ip)
                           select row;
                if (temp.Count() > 0)
                {
                    Global.OnLineUserList.Remove(temp.First());
                    OnlineChange();
                    _message.AppendLine(ip.ToString() + " offline");
                    tbInfo.Text = _message.ToString();
                }
            }
        }

        private void ListenCallback()
        {
            _message.AppendLine("Server started.");
            tbInfo.Text = _message.ToString();
        }

        private void ListenErrorCallback(Exception ex)
        {
            this.Close();
            LANTalkForm.LANTalkIcon.BalloonTipText = "Server not start,detail:" + ex.Message;
            LANTalkForm.LANTalkIcon.ShowBalloonTip(60000);
            LANTalk.Mode = 0;
            LANTalkForm.Show();
            LANTalkForm.Activate();
        }

        private void ReceiveCallback(IPAddress ip, string content)
        {
            try
            {
                var contents = content.Split(' ');
                var id = contents[0];
                var mode = contents[1];
                var fromip = contents[2];
                var toip = contents[3];
                var message = string.Empty;
                var messageindex = content.IndexOf(contents[3]) + contents[3].Length;
                if (messageindex < content.Length)
                {
                    message = content.Substring(messageindex + 1);
                }

                lock (Global.OnLineUserList)
                {
                    var client = from user in Global.OnLineUserList
                                 where user.IP.Equals(ip)
                                 select user;

                    SendContent sendContent;

                    var tos = toip.Split(',');
                    foreach (var rto in tos)
                    {
                        switch ((SendMode)Enum.Parse(typeof(SendMode), mode))
                        {
                            case SendMode.send:
                                sendContent = new SendContent();
                                if (rto == "server")
                                {
                                    WriteToAccess(fromip, toip, message);
                                    var appendmessage = ip.ToString() + ":";
                                    appendmessage += message;
                                    WriteMessage(appendmessage);
                                    sendContent.Id = Guid.Parse(id);
                                    sendContent.Mode = SendMode.request.ToString();
                                    sendContent.From = fromip;
                                    sendContent.To = rto;
                                    sendContent.Sent = false;

                                    foreach (var cli in client)
                                    {
                                        cli.SendList.Add(sendContent);
                                    }

                                }
                                else
                                {
                                    var clientto = from user in Global.OnLineUserList
                                                   where user.IP.Equals(IPAddress.Parse(rto))
                                                   select user;

                                    sendContent.Id = Guid.Parse(id);
                                    sendContent.Mode = SendMode.send.ToString();
                                    sendContent.From = fromip;
                                    sendContent.To = rto;
                                    sendContent.Message = message;
                                    sendContent.Sent = false;

                                    foreach (var cli in clientto)
                                    {
                                        cli.SendList.Add(sendContent);
                                    }
                                }
                                break;
                            case SendMode.request:
                                sendContent = new SendContent();
                                foreach (var cli in client)
                                {
                                    lock (cli.SendList)
                                    {
                                        var list = from row in cli.SendList
                                                   where row.Id.Equals(Guid.Parse(id)) && IPAddress.Parse(row.To).Equals(ip) 
                                                   select row;

                                        foreach (var li in list)
                                        {
                                            message = li.Message;
                                            cli.SendList.Remove(li);
                                        }
                                    }
                                }
                                if (fromip != "server")
                                {
                                    WriteToAccess(fromip, rto, message);

                                    var clientto = from user in Global.OnLineUserList
                                                   where user.IP.Equals(IPAddress.Parse(fromip))
                                                   select user;

                                    sendContent.Id = Guid.Parse(id);
                                    sendContent.Mode = SendMode.request.ToString();
                                    sendContent.From = fromip;
                                    sendContent.To = toip;
                                    foreach (var cli in clientto)
                                    {
                                        cli.SendList.Add(sendContent);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var cguid = Guid.NewGuid();
            var message = tbSend.Text;
            for (var i = 1; i < clbOnlineList.SelectedItems.Count; i++)
            {
                SendContent sendContent = new SendContent();
                sendContent.Id = cguid;
                sendContent.Mode = SendMode.send.ToString();
                sendContent.From = "server";
                sendContent.To = clbOnlineList.SelectedItems[i].ToString();
                sendContent.Message = message;
                sendContent.Sent = false;
            }

            //var parStart = new ParameterizedThreadStart(Handle);
            //var recieveThread = new Thread(parStart);
            //recieveThread.IsBackground = true;
            //object o = temp;
            //recieveThread.Start(o);
        }

        private void Handle(string ips, Guid guid, string message)
        {
        }
    }
}
