using LANTalk.Properties;
namespace LANTalk
{
    partial class LANTalk
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LANTalkIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.IconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitTool = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.lbServerIP = new System.Windows.Forms.Label();
            this.lbServerPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lsbIPAddress = new System.Windows.Forms.ListBox();
            this.lbClientIP = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.ttLANTalk = new System.Windows.Forms.ToolTip(this.components);
            this.IconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LANTalkIcon
            // 
            this.LANTalkIcon.ContextMenuStrip = this.IconMenu;
            this.LANTalkIcon.Icon = global::LANTalk.Properties.Resources.LANTalkicon;
            this.LANTalkIcon.Text = "LANTalkIcon";
            this.LANTalkIcon.Visible = true;
            this.LANTalkIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LANTalkIcon_MouseClick);
            // 
            // IconMenu
            // 
            this.IconMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(124)))), ((int)(((byte)(176)))));
            this.IconMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitTool});
            this.IconMenu.Name = "IconMenu";
            this.IconMenu.ShowImageMargin = false;
            this.IconMenu.Size = new System.Drawing.Size(72, 26);
            // 
            // exitTool
            // 
            this.exitTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitTool.Name = "exitTool";
            this.exitTool.Size = new System.Drawing.Size(71, 22);
            this.exitTool.Text = "Exit";
            this.exitTool.Click += new System.EventHandler(this.exitTool_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(134, 159);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Location = new System.Drawing.Point(12, 12);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(59, 16);
            this.rbServer.TabIndex = 4;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(12, 95);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(59, 16);
            this.rbClient.TabIndex = 5;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(27, 37);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(17, 12);
            this.lbServerIP.TabIndex = 6;
            this.lbServerIP.Text = "IP";
            // 
            // lbServerPort
            // 
            this.lbServerPort.AutoSize = true;
            this.lbServerPort.Location = new System.Drawing.Point(27, 162);
            this.lbServerPort.Name = "lbServerPort";
            this.lbServerPort.Size = new System.Drawing.Size(29, 12);
            this.lbServerPort.TabIndex = 8;
            this.lbServerPort.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(62, 159);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(53, 21);
            this.tbPort.TabIndex = 9;
            this.tbPort.Text = "8080";
            // 
            // lsbIPAddress
            // 
            this.lsbIPAddress.FormattingEnabled = true;
            this.lsbIPAddress.ItemHeight = 12;
            this.lsbIPAddress.Items.AddRange(new object[] {
            "255.255.255.255"});
            this.lsbIPAddress.Location = new System.Drawing.Point(50, 37);
            this.lsbIPAddress.Name = "lsbIPAddress";
            this.lsbIPAddress.Size = new System.Drawing.Size(159, 52);
            this.lsbIPAddress.TabIndex = 10;
            // 
            // lbClientIP
            // 
            this.lbClientIP.AutoSize = true;
            this.lbClientIP.Location = new System.Drawing.Point(10, 120);
            this.lbClientIP.Name = "lbClientIP";
            this.lbClientIP.Size = new System.Drawing.Size(41, 12);
            this.lbClientIP.TabIndex = 11;
            this.lbClientIP.Text = "Server";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(51, 117);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(158, 21);
            this.tbIPAddress.TabIndex = 14;
            // 
            // ttLANTalk
            // 
            this.ttLANTalk.IsBalloon = true;
            // 
            // LANTalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(221, 192);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.lbClientIP);
            this.Controls.Add(this.lsbIPAddress);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lbServerPort);
            this.Controls.Add(this.lbServerIP);
            this.Controls.Add(this.rbClient);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "LANTalk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANTalk";
            this.IconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip IconMenu;
        private System.Windows.Forms.ToolStripMenuItem exitTool;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label lbServerPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.ListBox lsbIPAddress;
        private System.Windows.Forms.Label lbClientIP;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.ToolTip ttLANTalk;
        public System.Windows.Forms.NotifyIcon LANTalkIcon;
    }
}

