namespace FactoryBoard
{
    partial class WHOrder
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
            this.lbProcess = new System.Windows.Forms.Label();
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.dtpRequest_Time = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbRequest_Time = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbRequset_Qty = new System.Windows.Forms.Label();
            this.lbPN = new System.Windows.Forms.Label();
            this.lbIPN = new System.Windows.Forms.Label();
            this.tbRequset_Qty = new System.Windows.Forms.TextBox();
            this.tbPN = new System.Windows.Forms.TextBox();
            this.tbMO = new System.Windows.Forms.TextBox();
            this.tbIPN = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbProcess
            // 
            this.lbProcess.AutoSize = true;
            this.lbProcess.Location = new System.Drawing.Point(3, 104);
            this.lbProcess.Name = "lbProcess";
            this.lbProcess.Size = new System.Drawing.Size(83, 12);
            this.lbProcess.TabIndex = 70;
            this.lbProcess.Text = "Process(工艺)";
            // 
            // tbProcess
            // 
            this.tbProcess.Location = new System.Drawing.Point(146, 101);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(135, 21);
            this.tbProcess.TabIndex = 69;
            // 
            // dtpRequest_Time
            // 
            this.dtpRequest_Time.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpRequest_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequest_Time.Location = new System.Drawing.Point(146, 181);
            this.dtpRequest_Time.Name = "dtpRequest_Time";
            this.dtpRequest_Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpRequest_Time.Size = new System.Drawing.Size(135, 21);
            this.dtpRequest_Time.TabIndex = 68;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(102, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 67;
            this.btnCancel.Text = "Cancel(取消)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.Location = new System.Drawing.Point(3, 219);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 23);
            this.btnConfirm.TabIndex = 66;
            this.btnConfirm.Text = "Confirm(确认)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbRequest_Time
            // 
            this.lbRequest_Time.AutoSize = true;
            this.lbRequest_Time.Location = new System.Drawing.Point(3, 185);
            this.lbRequest_Time.Name = "lbRequest_Time";
            this.lbRequest_Time.Size = new System.Drawing.Size(137, 12);
            this.lbRequest_Time.TabIndex = 65;
            this.lbRequest_Time.Text = "Request_Time(需求时间)";
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Location = new System.Drawing.Point(3, 77);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(65, 12);
            this.lbMO.TabIndex = 64;
            this.lbMO.Text = "MO(工单号)";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(3, 23);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(95, 12);
            this.lbModel.TabIndex = 63;
            this.lbModel.Text = "Model(产品型号)";
            // 
            // lbRequset_Qty
            // 
            this.lbRequset_Qty.AutoSize = true;
            this.lbRequset_Qty.Location = new System.Drawing.Point(3, 158);
            this.lbRequset_Qty.Name = "lbRequset_Qty";
            this.lbRequset_Qty.Size = new System.Drawing.Size(131, 12);
            this.lbRequset_Qty.TabIndex = 62;
            this.lbRequset_Qty.Text = "Requset_Qty(需求数量)";
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(3, 131);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(59, 12);
            this.lbPN.TabIndex = 61;
            this.lbPN.Text = "P/N(品号)";
            // 
            // lbIPN
            // 
            this.lbIPN.AutoSize = true;
            this.lbIPN.Location = new System.Drawing.Point(3, 50);
            this.lbIPN.Name = "lbIPN";
            this.lbIPN.Size = new System.Drawing.Size(71, 12);
            this.lbIPN.TabIndex = 60;
            this.lbIPN.Text = "IPN(订单号)";
            // 
            // tbRequset_Qty
            // 
            this.tbRequset_Qty.Location = new System.Drawing.Point(146, 155);
            this.tbRequset_Qty.Name = "tbRequset_Qty";
            this.tbRequset_Qty.Size = new System.Drawing.Size(135, 21);
            this.tbRequset_Qty.TabIndex = 59;
            // 
            // tbPN
            // 
            this.tbPN.Location = new System.Drawing.Point(146, 128);
            this.tbPN.Name = "tbPN";
            this.tbPN.Size = new System.Drawing.Size(135, 21);
            this.tbPN.TabIndex = 58;
            // 
            // tbMO
            // 
            this.tbMO.Location = new System.Drawing.Point(146, 74);
            this.tbMO.Name = "tbMO";
            this.tbMO.Size = new System.Drawing.Size(135, 21);
            this.tbMO.TabIndex = 57;
            // 
            // tbIPN
            // 
            this.tbIPN.Location = new System.Drawing.Point(146, 47);
            this.tbIPN.Name = "tbIPN";
            this.tbIPN.Size = new System.Drawing.Size(135, 21);
            this.tbIPN.TabIndex = 56;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(146, 20);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(135, 21);
            this.tbModel.TabIndex = 55;
            // 
            // WHOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 263);
            this.Controls.Add(this.lbProcess);
            this.Controls.Add(this.tbProcess);
            this.Controls.Add(this.dtpRequest_Time);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbRequest_Time);
            this.Controls.Add(this.lbMO);
            this.Controls.Add(this.lbModel);
            this.Controls.Add(this.lbRequset_Qty);
            this.Controls.Add(this.lbPN);
            this.Controls.Add(this.lbIPN);
            this.Controls.Add(this.tbRequset_Qty);
            this.Controls.Add(this.tbPN);
            this.Controls.Add(this.tbMO);
            this.Controls.Add(this.tbIPN);
            this.Controls.Add(this.tbModel);
            this.Name = "WHOrder";
            this.Text = "WHOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProcess;
        private System.Windows.Forms.TextBox tbProcess;
        private System.Windows.Forms.DateTimePicker dtpRequest_Time;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbRequest_Time;
        private System.Windows.Forms.Label lbMO;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbRequset_Qty;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.Label lbIPN;
        private System.Windows.Forms.TextBox tbRequset_Qty;
        private System.Windows.Forms.TextBox tbPN;
        private System.Windows.Forms.TextBox tbMO;
        private System.Windows.Forms.TextBox tbIPN;
        private System.Windows.Forms.TextBox tbModel;
    }
}