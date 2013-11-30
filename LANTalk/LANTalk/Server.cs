using System;
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
            request,
            getuser
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
                    clbOnlineList.Items.Add(user.IP + (user.Name == string.Empty ? "" : "(" + user.Name + ")"));
                }
            }
        }

        private void WriteToAccess(string from, string to, string content)
        {
        }

        private void WriteMessage(string content)
        {
            //_message.AppendLine(content);
            //tbInfo.Text = _message.ToString();
            tbInfo.AppendText(content + "\r\n");

            this.tbInfo.SelectionLength = 0;
            this.tbInfo.ScrollToCaret();
        }

        
        
        private string SendBefore(Socket socketor)
        {
            var returnString = string.Empty;
            lock (Global.OnLineUserList)
            {
                if (Global.OnLineUserList.Count > 0)
                {
                    IPEndPoint clientipe = (IPEndPoint)socketor.RemoteEndPoint;
                    var user = Global.OnLineUserList.Where(o => o.IP == clientipe.Address.ToString()).First();
                    returnString = user.GetFirstSendContent();
                }
            }
            return returnString;
        }

        private void SocketAcceptCallback(Socket socketor)
        {
            var ip = ((IPEndPoint)socketor.RemoteEndPoint).Address.ToString();
            var User = new OnlineUser(ip);
            lock (Global.OnLineUserList)
            {
                Global.OnLineUserList.Add(User);
                OnlineChange();
            }
            _message.AppendLine(ip.ToString() + " online");
            tbInfo.Text = _message.ToString();
        }

        private void SocketLostCallback(Socket socketor)
        {
            var ip = ((IPEndPoint)socketor.RemoteEndPoint).Address.ToString();

            lock (Global.OnLineUserList)
            {
                var temp = from row in Global.OnLineUserList
                           where row.IP == ip.ToString()
                           select row;

                if (Global.OnLineUserList.RemoveAll(delegate(OnlineUser user)
                 {
                     return user.IP == ip.ToString();
                 }) > 0)
                {
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
            LANTalkForm.ShowBalloonTip("notice", "Server not start,detail:" + ex.Message);
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
                                 where user.IP == ip.ToString()
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
                                                   where user.IP == rto
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
                                                   where row.Id.Equals(Guid.Parse(id)) && row.To == ip.ToString()
                                                   select row;

                                        foreach (var li in list)
                                        {
                                            message = li.Message;
                                        }

                                        cli.SendList.RemoveAll(delegate(SendContent cont)
                                        {
                                            return cont.Id.Equals(Guid.Parse(id)) && cont.To == ip.ToString();
                                        });
                                    }
                                }
                                WriteToAccess(fromip, rto, message);

                                if (fromip != "server")
                                {
                                    var clientto = from user in Global.OnLineUserList
                                                   where user.IP == fromip
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
                            case SendMode.getuser:
                                sendContent = new SendContent();
                                var users = "server,";
                                foreach (var user in Global.OnLineUserList)
                                {
                                    users += user.IP + ",";
                                }
                                users = users.TrimEnd(',');
                                foreach (var cli in client)
                                {
                                    sendContent.Id = Guid.Parse(id);
                                    sendContent.Mode = SendMode.getuser.ToString();
                                    sendContent.From = fromip;
                                    sendContent.To = toip;
                                    sendContent.Message = users;
                                    cli.SendList.Add(sendContent);
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteMessage(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbSend.Text.Trim().Length == 0)
            {
                return;
            }

            lock (Global.OnLineUserList)
            {
                if (clbOnlineList.CheckedItems.Count > 0)
                {
                    var toips = string.Empty;
                    var selected = new string[clbOnlineList.CheckedItems.Count];
                    clbOnlineList.CheckedItems.CopyTo(selected, 0);

                    var selectitem = from item in selected
                                     where item != "All/None"
                                     select item;

                    if (selectitem.Count() > 0)
                    {
                        var cguid = Guid.NewGuid();
                        var message = tbSend.Text;
                        var o = new List<string>();
                        o.Add(cguid.ToString());
                        o.Add(message);
                        for (var i = 0; i < selectitem.Count(); i++)
                        {
                            SendContent sendContent = new SendContent();
                            sendContent.Id = cguid;
                            sendContent.Mode = SendMode.send.ToString();
                            sendContent.From = "server";
                            sendContent.To = selectitem.ToArray()[i].ToString();
                            sendContent.Message = message;
                            sendContent.Sent = false;

                            toips += selectitem.ToArray()[i].ToString() + ",";

                            o.Add(sendContent.To);

                            var clientto = from user in Global.OnLineUserList
                                           where user.IP.ToString() == sendContent.To
                                           select user;
                            foreach (var cli in clientto)
                            {
                                cli.SendList.Add(sendContent);
                            }
                        }

                        toips = toips.TrimEnd(',');
                        WriteMessage(DateTime.Now.ToString() + " To[" + toips + "]:" + message);

                        tbSend.Text = string.Empty;


                        var parStart = new ParameterizedThreadStart(CHandle);
                        var recieveThread = new Thread(parStart);
                        recieveThread.IsBackground = true;
                        recieveThread.Start(o);
                    }
                }
            }
        }

        private void CHandle(object par)
        {
            Thread.Sleep(3000);
            lock (Global.OnLineUserList)
            {
                var list = (List<string>)par;
                var guid = Guid.Parse(list[0]);
                var message = list[1];

                var success = "";
                var fail = "";

                for (var i = 2; i < list.Count; i++)
                {
                    var client = from user in Global.OnLineUserList
                                 where user.IP == list[i]
                                 select user;
                    foreach (var user in client)
                    {
                        var count = user.SendList.Where(o => o.Id == guid).Count();
                        if (count > 0)
                        {
                            fail += list[i] + ",";
                            user.SendList.RemoveAll(delegate(SendContent content)
                            {
                                return content.Id == guid;
                            });
                            break;
                        }
                        else if (count == 0)
                        {
                            success += list[i] + ",";
                            break;
                        }
                    }
                }


                //if (success.Length > 0)
                //{
                //    success = success.TrimEnd(',');
                //    WriteMessage("To " + success + ":" + message);
                //}
                if (fail.Length > 0)
                {
                    fail = fail.TrimEnd(',');
                    WriteMessage(fail + " 发送失败！");
                }
            }
        }
    }
}
