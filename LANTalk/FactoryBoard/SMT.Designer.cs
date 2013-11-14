namespace FactoryBoard
{
    partial class SMT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lbOffer = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSetting = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbTime2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOffer = new System.Windows.Forms.Button();
            this.tagOffer = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dglOffer = new System.Windows.Forms.DataGridView();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tagMain = new System.Windows.Forms.TabPage();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dglMain = new System.Windows.Forms.DataGridView();
            this.lbSMTTitle = new System.Windows.Forms.Label();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tagOffer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tagMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Location = new System.Drawing.Point(627, 66);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 23);
            this.btnConnect.TabIndex = 20;
            this.btnConnect.Text = "Connect(连接)";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lbOffer
            // 
            this.lbOffer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOffer.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOffer.Location = new System.Drawing.Point(3, 3);
            this.lbOffer.Name = "lbOffer";
            this.lbOffer.Size = new System.Drawing.Size(934, 60);
            this.lbOffer.TabIndex = 17;
            this.lbOffer.Text = "Offer Information";
            this.lbOffer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(895, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "CSV文件|*.csv";
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(859, 35);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(755, 79);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(179, 12);
            this.lbTime.TabIndex = 10;
            this.lbTime.Text = "Date:yyyy-MM-dd Time:HH:mm:ss";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AutoSize = true;
            this.btnOpenFile.Location = new System.Drawing.Point(6, 66);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(87, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "Import(导入)";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(534, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete(删除)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lbTime2
            // 
            this.lbTime2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime2.AutoSize = true;
            this.lbTime2.Location = new System.Drawing.Point(755, 79);
            this.lbTime2.Name = "lbTime2";
            this.lbTime2.Size = new System.Drawing.Size(179, 12);
            this.lbTime2.TabIndex = 20;
            this.lbTime2.Text = "Date:yyyy-MM-dd Time:HH:mm:ss";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FactoryBoard.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnOffer
            // 
            this.btnOffer.AutoSize = true;
            this.btnOffer.Enabled = false;
            this.btnOffer.Location = new System.Drawing.Point(6, 66);
            this.btnOffer.Name = "btnOffer";
            this.btnOffer.Size = new System.Drawing.Size(86, 23);
            this.btnOffer.TabIndex = 18;
            this.btnOffer.Text = "Offer(供料)";
            this.btnOffer.UseVisualStyleBackColor = true;
            this.btnOffer.Click += new System.EventHandler(this.btnOffer_Click);
            // 
            // tagOffer
            // 
            this.tagOffer.Controls.Add(this.lbTime2);
            this.tagOffer.Controls.Add(this.btnOffer);
            this.tagOffer.Controls.Add(this.pictureBox3);
            this.tagOffer.Controls.Add(this.dglOffer);
            this.tagOffer.Controls.Add(this.lbOffer);
            this.tagOffer.Location = new System.Drawing.Point(4, 4);
            this.tagOffer.Name = "tagOffer";
            this.tagOffer.Padding = new System.Windows.Forms.Padding(3);
            this.tagOffer.Size = new System.Drawing.Size(940, 416);
            this.tagOffer.TabIndex = 2;
            this.tagOffer.Text = "Offer(供料)";
            this.tagOffer.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FactoryBoard.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(173, 63);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
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
            this.dglOffer.Location = new System.Drawing.Point(0, 94);
            this.dglOffer.MultiSelect = false;
            this.dglOffer.Name = "dglOffer";
            this.dglOffer.ReadOnly = true;
            this.dglOffer.RowTemplate.Height = 23;
            this.dglOffer.Size = new System.Drawing.Size(941, 322);
            this.dglOffer.TabIndex = 15;
            this.dglOffer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dglOffer_DataBindingComplete);
            // 
            // tabMain
            // 
            this.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabMain.Controls.Add(this.tagMain);
            this.tabMain.Controls.Add(this.tagOffer);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(0, 0);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(948, 441);
            this.tabMain.TabIndex = 3;
            // 
            // tagMain
            // 
            this.tagMain.Controls.Add(this.btnConnect);
            this.tagMain.Controls.Add(this.btnExit);
            this.tagMain.Controls.Add(this.btnSetting);
            this.tagMain.Controls.Add(this.lbTime);
            this.tagMain.Controls.Add(this.pictureBox1);
            this.tagMain.Controls.Add(this.btnOpenFile);
            this.tagMain.Controls.Add(this.btnDelete);
            this.tagMain.Controls.Add(this.btnRevert);
            this.tagMain.Controls.Add(this.btnSave);
            this.tagMain.Controls.Add(this.btnEdit);
            this.tagMain.Controls.Add(this.btnAdd);
            this.tagMain.Controls.Add(this.btnPrint);
            this.tagMain.Controls.Add(this.dglMain);
            this.tagMain.Controls.Add(this.lbSMTTitle);
            this.tagMain.Location = new System.Drawing.Point(4, 4);
            this.tagMain.Name = "tagMain";
            this.tagMain.Padding = new System.Windows.Forms.Padding(3);
            this.tagMain.Size = new System.Drawing.Size(940, 416);
            this.tagMain.TabIndex = 0;
            this.tagMain.Text = "Info(信息)";
            this.tagMain.UseVisualStyleBackColor = true;
            // 
            // btnRevert
            // 
            this.btnRevert.AutoSize = true;
            this.btnRevert.Location = new System.Drawing.Point(180, 66);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(99, 23);
            this.btnRevert.TabIndex = 5;
            this.btnRevert.Text = "Undo(撤销更改)";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(99, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save(保存)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Location = new System.Drawing.Point(453, 66);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit(编辑)";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Location = new System.Drawing.Point(372, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add(增加)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = true;
            this.btnPrint.Location = new System.Drawing.Point(285, 66);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print(打印)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dglMain
            // 
            this.dglMain.AllowUserToAddRows = false;
            this.dglMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dglMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dglMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dglMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dglMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dglMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglMain.DefaultCellStyle = dataGridViewCellStyle6;
            this.dglMain.Location = new System.Drawing.Point(0, 94);
            this.dglMain.MultiSelect = false;
            this.dglMain.Name = "dglMain";
            this.dglMain.ReadOnly = true;
            this.dglMain.RowTemplate.Height = 23;
            this.dglMain.Size = new System.Drawing.Size(940, 322);
            this.dglMain.TabIndex = 0;
            this.dglMain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dglMain_CellMouseDoubleClick);
            this.dglMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dglMain_DataBindingComplete);
            // 
            // lbSMTTitle
            // 
            this.lbSMTTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbSMTTitle.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSMTTitle.Location = new System.Drawing.Point(3, 3);
            this.lbSMTTitle.Name = "lbSMTTitle";
            this.lbSMTTitle.Size = new System.Drawing.Size(934, 60);
            this.lbSMTTitle.TabIndex = 9;
            this.lbSMTTitle.Text = "SMT Status Information";
            this.lbSMTTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Interval = 1000;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // SMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 441);
            this.Controls.Add(this.tabMain);
            this.Name = "SMT";
            this.Text = "SMT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SMT_FormClosed);
            this.Load += new System.EventHandler(this.SMT_Load);
            this.Shown += new System.EventHandler(this.SMT_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tagOffer.ResumeLayout(false);
            this.tagOffer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOffer)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tagMain.ResumeLayout(false);
            this.tagMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lbOffer;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lbTime2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOffer;
        private System.Windows.Forms.TabPage tagOffer;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dglOffer;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tagMain;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dglMain;
        private System.Windows.Forms.Label lbSMTTitle;
        private System.Windows.Forms.Timer tTime;
    }
}