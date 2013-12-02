namespace FactoryBoard
{
    partial class SSPOrder
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtpRequest_Time = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lbRequest_Time
            // 
            this.lbRequest_Time.AutoSize = true;
            this.lbRequest_Time.Location = new System.Drawing.Point(12, 144);
            this.lbRequest_Time.Name = "lbRequest_Time";
            this.lbRequest_Time.Size = new System.Drawing.Size(77, 12);
            this.lbRequest_Time.TabIndex = 39;
            this.lbRequest_Time.Text = "Request_Time";
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Location = new System.Drawing.Point(12, 63);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(23, 12);
            this.lbMO.TabIndex = 38;
            this.lbMO.Text = "MO";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(12, 9);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(35, 12);
            this.lbModel.TabIndex = 37;
            this.lbModel.Text = "Model";
            // 
            // lbRequset_Qty
            // 
            this.lbRequset_Qty.AutoSize = true;
            this.lbRequset_Qty.Location = new System.Drawing.Point(12, 117);
            this.lbRequset_Qty.Name = "lbRequset_Qty";
            this.lbRequset_Qty.Size = new System.Drawing.Size(71, 12);
            this.lbRequset_Qty.TabIndex = 36;
            this.lbRequset_Qty.Text = "Requset_Qty";
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(12, 90);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(23, 12);
            this.lbPN.TabIndex = 35;
            this.lbPN.Text = "P/N";
            // 
            // lbIPN
            // 
            this.lbIPN.AutoSize = true;
            this.lbIPN.Location = new System.Drawing.Point(12, 36);
            this.lbIPN.Name = "lbIPN";
            this.lbIPN.Size = new System.Drawing.Size(23, 12);
            this.lbIPN.TabIndex = 34;
            this.lbIPN.Text = "IPN";
            // 
            // tbRequset_Qty
            // 
            this.tbRequset_Qty.Location = new System.Drawing.Point(98, 114);
            this.tbRequset_Qty.Name = "tbRequset_Qty";
            this.tbRequset_Qty.Size = new System.Drawing.Size(135, 21);
            this.tbRequset_Qty.TabIndex = 32;
            // 
            // tbPN
            // 
            this.tbPN.Location = new System.Drawing.Point(98, 87);
            this.tbPN.Name = "tbPN";
            this.tbPN.Size = new System.Drawing.Size(135, 21);
            this.tbPN.TabIndex = 31;
            // 
            // tbMO
            // 
            this.tbMO.Location = new System.Drawing.Point(98, 60);
            this.tbMO.Name = "tbMO";
            this.tbMO.Size = new System.Drawing.Size(135, 21);
            this.tbMO.TabIndex = 28;
            // 
            // tbIPN
            // 
            this.tbIPN.Location = new System.Drawing.Point(98, 33);
            this.tbIPN.Name = "tbIPN";
            this.tbIPN.Size = new System.Drawing.Size(135, 21);
            this.tbIPN.TabIndex = 27;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(98, 6);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(135, 21);
            this.tbModel.TabIndex = 26;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.Location = new System.Drawing.Point(12, 178);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(63, 23);
            this.btnConfirm.TabIndex = 40;
            this.btnConfirm.Text = " Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(81, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtpRequest_Time
            // 
            this.dtpRequest_Time.CustomFormat = "yyyy/MM/dd hh:mm";
            this.dtpRequest_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequest_Time.Location = new System.Drawing.Point(98, 140);
            this.dtpRequest_Time.Name = "dtpRequest_Time";
            this.dtpRequest_Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpRequest_Time.Size = new System.Drawing.Size(135, 21);
            this.dtpRequest_Time.TabIndex = 50;
            // 
            // SSPOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 221);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SSPOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSPOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpRequest_Time;
    }
}