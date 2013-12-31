namespace FactoryBoard
{
    partial class WH
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            this.lbTime = new System.Windows.Forms.Label();
            this.btnOffer = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dglOffer = new System.Windows.Forms.DataGridView();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lbOffer = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbCancel = new System.Windows.Forms.Label();
            this.lbFinished = new System.Windows.Forms.Label();
            this.lbSending = new System.Windows.Forms.Label();
            this.lbWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).BeginInit();
            this.SuspendLayout();
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Interval = 1000;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(755, 91);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(179, 12);
            this.lbTime.TabIndex = 19;
            this.lbTime.Text = "Date:yyyy-MM-dd Time:HH:mm:ss";
            // 
            // btnOffer
            // 
            this.btnOffer.AutoSize = true;
            this.btnOffer.Enabled = false;
            this.btnOffer.Location = new System.Drawing.Point(6, 78);
            this.btnOffer.Name = "btnOffer";
            this.btnOffer.Size = new System.Drawing.Size(86, 23);
            this.btnOffer.TabIndex = 18;
            this.btnOffer.Text = "Offer(供料)";
            this.btnOffer.UseVisualStyleBackColor = true;
            this.btnOffer.Click += new System.EventHandler(this.btnOffer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FactoryBoard.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(6, -3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // dglOffer
            // 
            this.dglOffer.AllowUserToAddRows = false;
            this.dglOffer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dglOffer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dglOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dglOffer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dglOffer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglOffer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dglOffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglOffer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dglOffer.Location = new System.Drawing.Point(6, 106);
            this.dglOffer.MultiSelect = false;
            this.dglOffer.Name = "dglOffer";
            this.dglOffer.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglOffer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dglOffer.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dglOffer.RowTemplate.Height = 23;
            this.dglOffer.Size = new System.Drawing.Size(935, 323);
            this.dglOffer.TabIndex = 15;
            this.dglOffer.DataSourceChanged += new System.EventHandler(this.dglOffer_DataSourceChanged);
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "CSV文件|*.csv";
            // 
            // lbOffer
            // 
            this.lbOffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOffer.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOffer.Location = new System.Drawing.Point(0, 0);
            this.lbOffer.Name = "lbOffer";
            this.lbOffer.Size = new System.Drawing.Size(948, 60);
            this.lbOffer.TabIndex = 17;
            this.lbOffer.Text = "WH Offer Information";
            this.lbOffer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(98, 78);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(123, 23);
            this.btnConnect.TabIndex = 20;
            this.btnConnect.Text = "Disconnect(未连接)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(605, 77);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 21;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Visible = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Yellow;
            this.button4.Enabled = false;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(809, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(13, 13);
            this.button4.TabIndex = 41;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.GreenYellow;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(809, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(13, 13);
            this.button3.TabIndex = 40;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(809, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(13, 13);
            this.button2.TabIndex = 39;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(809, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(13, 13);
            this.button1.TabIndex = 38;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lbCancel
            // 
            this.lbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCancel.AutoSize = true;
            this.lbCancel.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCancel.Location = new System.Drawing.Point(828, 51);
            this.lbCancel.Name = "lbCancel";
            this.lbCancel.Size = new System.Drawing.Size(89, 13);
            this.lbCancel.TabIndex = 37;
            this.lbCancel.Text = "Cancel(取消)";
            // 
            // lbFinished
            // 
            this.lbFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFinished.AutoSize = true;
            this.lbFinished.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFinished.Location = new System.Drawing.Point(828, 37);
            this.lbFinished.Name = "lbFinished";
            this.lbFinished.Size = new System.Drawing.Size(116, 13);
            this.lbFinished.TabIndex = 36;
            this.lbFinished.Text = "Finished(已送达)";
            // 
            // lbSending
            // 
            this.lbSending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSending.AutoSize = true;
            this.lbSending.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSending.Location = new System.Drawing.Point(828, 23);
            this.lbSending.Name = "lbSending";
            this.lbSending.Size = new System.Drawing.Size(109, 13);
            this.lbSending.TabIndex = 35;
            this.lbSending.Text = "Sending(发送中)";
            // 
            // lbWait
            // 
            this.lbWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbWait.AutoSize = true;
            this.lbWait.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWait.Location = new System.Drawing.Point(828, 9);
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(75, 13);
            this.lbWait.TabIndex = 34;
            this.lbWait.Text = "Wait(等待)";
            // 
            // WH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 441);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbCancel);
            this.Controls.Add(this.lbFinished);
            this.Controls.Add(this.lbSending);
            this.Controls.Add(this.lbWait);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnOffer);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dglOffer);
            this.Controls.Add(this.lbOffer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WH";
            this.Text = "WH";
            this.Activated += new System.EventHandler(this.WH_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WH_FormClosed);
            this.Load += new System.EventHandler(this.WH_Load);
            this.Shown += new System.EventHandler(this.WH_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnOffer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dglOffer;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Label lbOffer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbCancel;
        private System.Windows.Forms.Label lbFinished;
        private System.Windows.Forms.Label lbSending;
        private System.Windows.Forms.Label lbWait;
    }
}