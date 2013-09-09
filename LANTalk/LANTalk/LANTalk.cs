using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Net;

namespace LANTalk
{
    public partial class LANTalk : Form
    {
        public static int Mode = 0;
        static Server ServerForm;
        static Client ClientForm;

        public LANTalk()
        {
            InitializeComponent();
            InitializeData();
        }

        private string[] GetLoaclIPList()
        {
            var IPList = new List<string>();

            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

            ManagementObjectCollection queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
                var IP = string.Empty;

                string[] addresses = (string[])mo["IPAddress"];
                if (addresses == null || addresses.Length == 0)
                {
                    continue;
                }

                var ipcount = IPList.Where(o => o == addresses[0]).Count();

                if (ipcount == 0)
                {
                    IPList.Add(addresses[0]);
                }
            }
            return IPList.ToArray();
        }

        private void InitializeData()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\LANTalk.config";

            lsbIPAddress.DataSource = GetLoaclIPList();
            var config = LoadConfig().Split('|');

            if (LoadConfig() != string.Empty)
            {
                var mode = 0;
                int.TryParse(config[0], out mode);
                try
                {
                    switch (mode)
                    {
                        case 0:
                            break;
                        case 1:
                            rbServer.Checked = true;
                            IPAddress.Parse(config[1]);
                            lsbIPAddress.SelectedItem = config[1];
                            break;
                        case 2:
                            rbClient.Checked = true;
                            IPAddress.Parse(config[1]);
                            tbIPAddress.Text = config[1];
                            break;
                    }
                }
                catch
                {
                    LANTalkIcon.BalloonTipTitle = "注意";
                    LANTalkIcon.BalloonTipText = "配置文件" + path + "中IP地址格式不正确";
                    LANTalkIcon.ShowBalloonTip(600000);//消失时间
                    //throw new Exception("配置文件" + path + "中IP地址格式不正确");
                }

                try
                {
                    int.Parse(config[2]);
                    tbPort.Text = config[2];
                }
                catch
                {
                    LANTalkIcon.BalloonTipTitle = "注意";
                    LANTalkIcon.BalloonTipText = "配置文件" + path + "中端口格式不正确";
                    LANTalkIcon.ShowBalloonTip(600000);//消失时间
                }
            }
        }

        private void SaveConfig()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var ipc = string.Empty;

            switch (Mode)
            {
                case 0:
                    break;
                case 1:
                    ipc = lsbIPAddress.SelectedValue.ToString();
                    break;
                case 2:
                    ipc = tbIPAddress.Text;
                    break;
            }

            var config = Mode.ToString() + "|" + ipc + "|" + tbPort.Text;
            File.WriteAllText(path + "\\LANTalk.config", config);
        }

        private string LoadConfig()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\LANTalk.config";
            if(File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return string.Empty;
        }

        private void LANTalkIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                IconMenu.Show();
            }
            if (e.Button == MouseButtons.Left)
            {
                switch (Mode)
                {
                    case 0:
                        this.Show();
                        this.Activate();
                        this.WindowState = FormWindowState.Normal;
                        break;
                    case 1:
                        ServerForm.Show();
                        ServerForm.Activate();
                        ServerForm.WindowState = FormWindowState.Normal;
                        break;
                    case 2:
                        ClientForm.Show();
                        ClientForm.Activate();
                        ClientForm.WindowState = FormWindowState.Normal;
                        break;
                }
            }
        }

        private void exitTool_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbServer.Checked)
            {
                Mode = 1;
                ServerForm = new Server(IPAddress.Parse(lsbIPAddress.SelectedValue.ToString()), int.Parse(tbPort.Text), this);
                this.Hide();
                ServerForm.Show();
            }
            else if (rbClient.Checked)
            {
                Mode = 2;
                ClientForm = new Client();
                this.Hide();
                ClientForm.Show();
            }
            SaveConfig();
        }

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            lsbIPAddress.Enabled = rbServer.Checked;
            tbIPAddress.Enabled = rbClient.Checked;
        }

        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            lsbIPAddress.Enabled = rbServer.Checked;
            tbIPAddress.Enabled = rbClient.Checked;
        }

    }
}
