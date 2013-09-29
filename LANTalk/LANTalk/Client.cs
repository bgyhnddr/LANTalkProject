using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace LANTalk
{
    public partial class Client : Form
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
        private Core.Client _client;

        public Client(IPAddress ip, int port, LANTalk form)
        {
            _ip = ip;
            _port = port;
            Global.OnLineUserList = new List<OnlineUser>();
            _message = new StringBuilder();
            LANTalkForm = form;
            InitializeComponent();
        }


        private void WriteMessage(string content)
        {
            //_message.AppendLine(content);
            //tbInfo.Text = _message.ToString();

            tbInfo.AppendText(content + "\r\n");

            this.tbInfo.SelectionLength = 0;
            this.tbInfo.ScrollToCaret();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            clbOnlineList.Items.Add("All/None");
            _client = new Core.Client();
            _client.ConnectServer(_ip, _port, ConnectCallback, ReceiveCallback, SendBefore, ErrorCallback);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (btnSend.Text == "Connect")
            {
                _client = new Core.Client();
                _client.ConnectServer(_ip, _port, ConnectCallback, ReceiveCallback, SendBefore, ErrorCallback);
            }
            else if (btnSend.Text == "Send")
            {
                if (tbSend.Text.Trim().Length > 0)
                {
                    Send();
                }
            }
        }

        private void Send()
        {
            var guid = Guid.NewGuid();
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
                        var message = tbSend.Text;
                        var o = new List<string>();
                        o.Add(guid.ToString());
                        o.Add(message);
                        for (var i = 0; i < selectitem.Count(); i++)
                        {
                            SendContent sendContent = new SendContent();
                            sendContent.Id = guid;
                            sendContent.Mode = SendMode.send.ToString();
                            sendContent.From = _client.ClientIP.ToString();
                            sendContent.To = selectitem.ToArray()[i].ToString();
                            sendContent.Message = message;

                            toips += selectitem.ToArray()[i].ToString() + ",";

                            o.Add(sendContent.To);

                            var clientto = from user in Global.OnLineUserList
                                           where user.IP == sendContent.To
                                           select user;
                            foreach (var cli in clientto)
                            {
                                cli.SendList.Add(sendContent);
                            }
                        }

                        toips = toips.TrimEnd(',');
                        WriteMessage(DateTime.Now.ToString() + " To[" + toips + "]:" + message);

                        _client.SendContent(BuildContent(guid, SendMode.send, _client.ClientIP.ToString(), string.Join(",", selectitem), tbSend.Text));
                        tbSend.Text = string.Empty;
                        var parStart = new ParameterizedThreadStart(CHandle);
                        var recieveThread = new Thread(parStart);
                        recieveThread.IsBackground = true;
                        recieveThread.Start(o);
                    }
                }
            }
        }

        private string BuildContent(Guid guid, SendMode mode, string fromip, string toip, string message = "")
        {
            return guid.ToString() + " " + mode.ToString() + " " + fromip + " " + toip + (message.Length > 0 ? " " + message : string.Empty);
        }

        private string SendBefore()
        {
            var guid = Guid.NewGuid();
            return BuildContent(guid, SendMode.getuser, _client.ClientIP.ToString(), "server");
        }

        private void ConnectCallback()
        {
            WriteMessage("connected");
            btnSend.Text = "Send";
        }

        private void ErrorCallback(Exception ex)
        {
            WriteMessage("connection error:" + ex.Message);
            btnSend.Text = "Connect";
        }

        private void CHandle(object par)
        {
            Thread.Sleep(600);
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
                        if (user.SendList.RemoveAll(delegate(SendContent content)
                        {
                            return content.Id == guid;
                        }) > 0)
                        {
                            fail += list[i] + ",";
                        }
                        else
                        {
                            success += list[i] + ",";
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
                    WriteMessage(fail + " request timeout");
                }
            }
        }

        private void OnlineChange(string list)
        {
            lock (Global.OnLineUserList)
            {
                var lists = list.Split(',');
                foreach (var li in lists)
                {
                    if (Global.OnLineUserList.Where(o => o.IP == li).Count() == 0)
                    {
                        Global.OnLineUserList.Clear();
                        if (list.Length > 0)
                        {
                            foreach (var sli in list.Split(','))
                            {
                                Global.OnLineUserList.Add(new OnlineUser(sli));
                            }
                        }


                        clbOnlineList.Items.Clear();
                        clbOnlineList.Items.Add("All/None");
                        foreach (var user in Global.OnLineUserList)
                        {
                            if (_client.ClientIP.ToString() == user.IP)
                            {
                                continue;
                            }
                            clbOnlineList.Items.Add(user.IP + (user.Name == string.Empty ? "" : "(" + user.Name + ")"));
                        }
                        return;
                    }
                }





            }
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

                    switch ((SendMode)Enum.Parse(typeof(SendMode), mode))
                    {
                        case SendMode.send:
                            var appendmessage = fromip + ":";
                            appendmessage += message;
                            WriteMessage(appendmessage);
                            _client.SendContent(BuildContent(Guid.Parse(id), SendMode.request, fromip, toip));
                            break;
                        case SendMode.request:
                            var target = from user in Global.OnLineUserList
                                         where user.IP == toip
                                         select user;

                            foreach (var tar in target)
                            {
                                lock (tar.SendList)
                                {
                                    var list = from row in tar.SendList
                                               where row.Id.Equals(Guid.Parse(id))
                                               select row;

                                    foreach (var li in list)
                                    {
                                        message = li.Message;
                                    }

                                    tar.SendList.RemoveAll(delegate(SendContent cont)
                                    {
                                        return cont.Id.Equals(Guid.Parse(id));
                                    });
                                }
                            }
                            break;
                        case SendMode.getuser:
                            OnlineChange(message);
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                WriteMessage(ex.Message);
            }
        }

        private void Client_Resize(object sender, EventArgs e)
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

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意判断关闭事件Reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                WindowState = FormWindowState.Minimized;    //使关闭时窗口向右下角缩小的效果
                return;
            }
        }
    }
}
