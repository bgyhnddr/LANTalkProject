namespace LANTalk
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.clbOnlineList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInfo.Location = new System.Drawing.Point(116, 0);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfo.Size = new System.Drawing.Size(494, 209);
            this.tbInfo.TabIndex = 7;
            // 
            // tbSend
            // 
            this.tbSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbSend.Location = new System.Drawing.Point(116, 209);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(494, 68);
            this.tbSend.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(226)))), ((int)(((byte)(197)))));
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Location = new System.Drawing.Point(116, 277);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(494, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Connect";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // clbOnlineList
            // 
            this.clbOnlineList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.clbOnlineList.Dock = System.Windows.Forms.DockStyle.Left;
            this.clbOnlineList.FormattingEnabled = true;
            this.clbOnlineList.Location = new System.Drawing.Point(0, 0);
            this.clbOnlineList.Name = "clbOnlineList";
            this.clbOnlineList.Size = new System.Drawing.Size(116, 300);
            this.clbOnlineList.TabIndex = 4;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 300);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.clbOnlineList);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.Resize += new System.EventHandler(this.Client_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckedListBox clbOnlineList;



    }
}