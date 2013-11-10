namespace FactoryBoard
{
    partial class eWH
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnOffer = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbOffer = new System.Windows.Forms.Label();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dglOffer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(902, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 23);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(866, 36);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 29;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Interval = 1000;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Location = new System.Drawing.Point(98, 85);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 23);
            this.btnConnect.TabIndex = 28;
            this.btnConnect.Text = "Connect(连接)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(755, 98);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(179, 12);
            this.lbTime.TabIndex = 27;
            this.lbTime.Text = "Date:yyyy-MM-dd Time:hh:mm:ss";
            // 
            // btnOffer
            // 
            this.btnOffer.AutoSize = true;
            this.btnOffer.Enabled = false;
            this.btnOffer.Location = new System.Drawing.Point(6, 85);
            this.btnOffer.Name = "btnOffer";
            this.btnOffer.Size = new System.Drawing.Size(86, 23);
            this.btnOffer.TabIndex = 26;
            this.btnOffer.Text = "Offer(供料)";
            this.btnOffer.UseVisualStyleBackColor = true;
            this.btnOffer.Click += new System.EventHandler(this.btnOffer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FactoryBoard.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(6, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // lbOffer
            // 
            this.lbOffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOffer.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOffer.Location = new System.Drawing.Point(0, 0);
            this.lbOffer.Name = "lbOffer";
            this.lbOffer.Size = new System.Drawing.Size(948, 60);
            this.lbOffer.TabIndex = 25;
            this.lbOffer.Text = "W/H Offer Information";
            this.lbOffer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "CSV文件|*.csv";
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
            this.dglOffer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dglOffer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglOffer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dglOffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglOffer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dglOffer.Location = new System.Drawing.Point(6, 113);
            this.dglOffer.MultiSelect = false;
            this.dglOffer.Name = "dglOffer";
            this.dglOffer.ReadOnly = true;
            this.dglOffer.RowTemplate.Height = 23;
            this.dglOffer.Size = new System.Drawing.Size(935, 323);
            this.dglOffer.TabIndex = 23;
            this.dglOffer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dglOffer_DataBindingComplete);
            // 
            // eWH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 441);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.btnOffer);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbOffer);
            this.Controls.Add(this.dglOffer);
            this.Name = "eWH";
            this.Text = "eWH";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.eWH_FormClosed);
            this.Load += new System.EventHandler(this.eWH_Load);
            this.Shown += new System.EventHandler(this.eWH_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Timer tTime;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnOffer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbOffer;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.DataGridView dglOffer;
    }
}