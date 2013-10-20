namespace FactoryBoard
{
    partial class ASS
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tagMain = new System.Windows.Forms.TabPage();
            this.btnSetting = new System.Windows.Forms.Button();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbASSTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dglMain = new System.Windows.Forms.DataGridView();
            this.tagOrder = new System.Windows.Forms.TabPage();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dglOrder = new System.Windows.Forms.DataGridView();
            this.btnIJ = new System.Windows.Forms.Button();
            this.btnSSP = new System.Windows.Forms.Button();
            this.btnSMT = new System.Windows.Forms.Button();
            this.btneWH = new System.Windows.Forms.Button();
            this.btnWH = new System.Windows.Forms.Button();
            this.ofdOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tTime = new System.Windows.Forms.Timer(this.components);
            this.tabMain.SuspendLayout();
            this.tagMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglMain)).BeginInit();
            this.tagOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabMain.Controls.Add(this.tagMain);
            this.tabMain.Controls.Add(this.tagOrder);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(0, 0);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(949, 456);
            this.tabMain.TabIndex = 1;
            // 
            // tagMain
            // 
            this.tagMain.Controls.Add(this.btnSetting);
            this.tagMain.Controls.Add(this.lbTime);
            this.tagMain.Controls.Add(this.lbASSTitle);
            this.tagMain.Controls.Add(this.pictureBox1);
            this.tagMain.Controls.Add(this.btnOpenFile);
            this.tagMain.Controls.Add(this.btnDelete);
            this.tagMain.Controls.Add(this.btnRevert);
            this.tagMain.Controls.Add(this.btnSave);
            this.tagMain.Controls.Add(this.btnEdit);
            this.tagMain.Controls.Add(this.btnAdd);
            this.tagMain.Controls.Add(this.btnPrint);
            this.tagMain.Controls.Add(this.dglMain);
            this.tagMain.Location = new System.Drawing.Point(4, 4);
            this.tagMain.Name = "tagMain";
            this.tagMain.Padding = new System.Windows.Forms.Padding(3);
            this.tagMain.Size = new System.Drawing.Size(941, 431);
            this.tagMain.TabIndex = 0;
            this.tagMain.Text = "生产线";
            this.tagMain.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(858, 36);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "配置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(8, 76);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 12);
            this.lbTime.TabIndex = 10;
            // 
            // lbASSTitle
            // 
            this.lbASSTitle.AutoSize = true;
            this.lbASSTitle.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbASSTitle.Location = new System.Drawing.Point(179, 29);
            this.lbASSTitle.Name = "lbASSTitle";
            this.lbASSTitle.Size = new System.Drawing.Size(384, 33);
            this.lbASSTitle.TabIndex = 9;
            this.lbASSTitle.Text = "Assembly Status Information";
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
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(374, 65);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 7;
            this.btnOpenFile.Text = "导入";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(858, 65);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevert.Location = new System.Drawing.Point(536, 65);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 5;
            this.btnRevert.Text = "撤销更改";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(455, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(777, 65);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(696, 65);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(615, 65);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dglMain
            // 
            this.dglMain.AllowUserToAddRows = false;
            this.dglMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dglMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dglMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dglMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dglMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dglMain.Location = new System.Drawing.Point(0, 94);
            this.dglMain.MultiSelect = false;
            this.dglMain.Name = "dglMain";
            this.dglMain.ReadOnly = true;
            this.dglMain.RowTemplate.Height = 23;
            this.dglMain.Size = new System.Drawing.Size(941, 336);
            this.dglMain.TabIndex = 0;
            this.dglMain.DataSourceChanged += new System.EventHandler(this.dglMain_DataSourceChanged);
            this.dglMain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dglMain_CellMouseDoubleClick);
            // 
            // tagOrder
            // 
            this.tagOrder.Controls.Add(this.btnDeleteOrder);
            this.tagOrder.Controls.Add(this.btnAddOrder);
            this.tagOrder.Controls.Add(this.btnOrder);
            this.tagOrder.Controls.Add(this.label1);
            this.tagOrder.Controls.Add(this.pictureBox2);
            this.tagOrder.Controls.Add(this.dglOrder);
            this.tagOrder.Controls.Add(this.btnIJ);
            this.tagOrder.Controls.Add(this.btnSSP);
            this.tagOrder.Controls.Add(this.btnSMT);
            this.tagOrder.Controls.Add(this.btneWH);
            this.tagOrder.Controls.Add(this.btnWH);
            this.tagOrder.Location = new System.Drawing.Point(4, 4);
            this.tagOrder.Name = "tagOrder";
            this.tagOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tagOrder.Size = new System.Drawing.Size(941, 431);
            this.tagOrder.TabIndex = 1;
            this.tagOrder.Text = "要料";
            this.tagOrder.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(777, 65);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 14;
            this.btnDeleteOrder.Text = "删除";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(696, 65);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrder.TabIndex = 13;
            this.btnAddOrder.Text = "添加";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(858, 65);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 12;
            this.btnOrder.Text = "要料";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ass Pull Information";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FactoryBoard.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // dglOrder
            // 
            this.dglOrder.AllowUserToAddRows = false;
            this.dglOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dglOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dglOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dglOrder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dglOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(129)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dglOrder.DefaultCellStyle = dataGridViewCellStyle6;
            this.dglOrder.Location = new System.Drawing.Point(0, 94);
            this.dglOrder.MultiSelect = false;
            this.dglOrder.Name = "dglOrder";
            this.dglOrder.ReadOnly = true;
            this.dglOrder.RowTemplate.Height = 23;
            this.dglOrder.Size = new System.Drawing.Size(941, 336);
            this.dglOrder.TabIndex = 6;
            this.dglOrder.DataSourceChanged += new System.EventHandler(this.dglOrder_DataSourceChanged);
            // 
            // btnIJ
            // 
            this.btnIJ.BackColor = System.Drawing.Color.Red;
            this.btnIJ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIJ.Location = new System.Drawing.Point(0, 72);
            this.btnIJ.Margin = new System.Windows.Forms.Padding(0);
            this.btnIJ.Name = "btnIJ";
            this.btnIJ.Size = new System.Drawing.Size(45, 23);
            this.btnIJ.TabIndex = 5;
            this.btnIJ.Text = "IJ";
            this.btnIJ.UseVisualStyleBackColor = false;
            this.btnIJ.Click += new System.EventHandler(this.btnIJ_Click);
            // 
            // btnSSP
            // 
            this.btnSSP.BackColor = System.Drawing.Color.Red;
            this.btnSSP.Enabled = false;
            this.btnSSP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSSP.Location = new System.Drawing.Point(180, 72);
            this.btnSSP.Margin = new System.Windows.Forms.Padding(0);
            this.btnSSP.Name = "btnSSP";
            this.btnSSP.Size = new System.Drawing.Size(45, 23);
            this.btnSSP.TabIndex = 4;
            this.btnSSP.Text = "SSP";
            this.btnSSP.UseVisualStyleBackColor = false;
            // 
            // btnSMT
            // 
            this.btnSMT.BackColor = System.Drawing.Color.Red;
            this.btnSMT.Enabled = false;
            this.btnSMT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSMT.Location = new System.Drawing.Point(135, 72);
            this.btnSMT.Margin = new System.Windows.Forms.Padding(0);
            this.btnSMT.Name = "btnSMT";
            this.btnSMT.Size = new System.Drawing.Size(45, 23);
            this.btnSMT.TabIndex = 3;
            this.btnSMT.Text = "SMT";
            this.btnSMT.UseVisualStyleBackColor = false;
            // 
            // btneWH
            // 
            this.btneWH.BackColor = System.Drawing.Color.Red;
            this.btneWH.Enabled = false;
            this.btneWH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btneWH.Location = new System.Drawing.Point(90, 72);
            this.btneWH.Margin = new System.Windows.Forms.Padding(0);
            this.btneWH.Name = "btneWH";
            this.btneWH.Size = new System.Drawing.Size(45, 23);
            this.btneWH.TabIndex = 2;
            this.btneWH.Text = "e-W/H";
            this.btneWH.UseVisualStyleBackColor = false;
            // 
            // btnWH
            // 
            this.btnWH.BackColor = System.Drawing.Color.Red;
            this.btnWH.Enabled = false;
            this.btnWH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWH.Location = new System.Drawing.Point(45, 72);
            this.btnWH.Margin = new System.Windows.Forms.Padding(0);
            this.btnWH.Name = "btnWH";
            this.btnWH.Size = new System.Drawing.Size(45, 23);
            this.btnWH.TabIndex = 1;
            this.btnWH.Text = "W/H";
            this.btnWH.UseVisualStyleBackColor = false;
            this.btnWH.Click += new System.EventHandler(this.btnWH_Click);
            // 
            // ofdOpenFile
            // 
            this.ofdOpenFile.Filter = "CSV文件|*.csv";
            // 
            // tTime
            // 
            this.tTime.Enabled = true;
            this.tTime.Interval = 1000;
            this.tTime.Tick += new System.EventHandler(this.tTime_Tick);
            // 
            // ASS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 456);
            this.Controls.Add(this.tabMain);
            this.Name = "ASS";
            this.Text = "ASS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ASS_FormClosed);
            this.Load += new System.EventHandler(this.ASS_Load);
            this.Shown += new System.EventHandler(this.ASS_Shown);
            this.tabMain.ResumeLayout(false);
            this.tagMain.ResumeLayout(false);
            this.tagMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglMain)).EndInit();
            this.tagOrder.ResumeLayout(false);
            this.tagOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tagMain;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dglMain;
        private System.Windows.Forms.TabPage tagOrder;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.OpenFileDialog ofdOpenFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSSP;
        private System.Windows.Forms.Button btnSMT;
        private System.Windows.Forms.Button btneWH;
        private System.Windows.Forms.Button btnWH;
        private System.Windows.Forms.Button btnIJ;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbASSTitle;
        private System.Windows.Forms.Timer tTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.DataGridView dglOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnAddOrder;
    }
}