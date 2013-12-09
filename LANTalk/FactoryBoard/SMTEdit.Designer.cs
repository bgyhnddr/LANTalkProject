namespace FactoryBoard
{
    partial class SMTEdit
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
            this.tbPN = new System.Windows.Forms.TextBox();
            this.lbPN = new System.Windows.Forms.Label();
            this.dtpStart_Time = new System.Windows.Forms.DateTimePicker();
            this.lbActual_Output = new System.Windows.Forms.Label();
            this.lbStart_Time = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.lbModel = new System.Windows.Forms.Label();
            this.lbDaily_Plan = new System.Windows.Forms.Label();
            this.lbOrder_Qty = new System.Windows.Forms.Label();
            this.lbIPN = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.btnMethod_Status = new System.Windows.Forms.Button();
            this.btnMaterial_Status = new System.Windows.Forms.Button();
            this.btnMachine_Status = new System.Windows.Forms.Button();
            this.btnMan_Status = new System.Windows.Forms.Button();
            this.tbMO = new System.Windows.Forms.TextBox();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbActual_Output = new System.Windows.Forms.TextBox();
            this.tbDaily_Plan = new System.Windows.Forms.TextBox();
            this.tbOrder_Qty = new System.Windows.Forms.TextBox();
            this.tbIPN = new System.Windows.Forms.TextBox();
            this.tbLine = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPN
            // 
            this.tbPN.Location = new System.Drawing.Point(143, 60);
            this.tbPN.Name = "tbPN";
            this.tbPN.Size = new System.Drawing.Size(107, 21);
            this.tbPN.TabIndex = 77;
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(14, 63);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(59, 12);
            this.lbPN.TabIndex = 76;
            this.lbPN.Text = "P/N(品号)";
            // 
            // dtpStart_Time
            // 
            this.dtpStart_Time.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpStart_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time.Location = new System.Drawing.Point(405, 87);
            this.dtpStart_Time.Name = "dtpStart_Time";
            this.dtpStart_Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpStart_Time.Size = new System.Drawing.Size(135, 21);
            this.dtpStart_Time.TabIndex = 75;
            // 
            // lbActual_Output
            // 
            this.lbActual_Output.AutoSize = true;
            this.lbActual_Output.Location = new System.Drawing.Point(256, 118);
            this.lbActual_Output.Name = "lbActual_Output";
            this.lbActual_Output.Size = new System.Drawing.Size(143, 12);
            this.lbActual_Output.TabIndex = 74;
            this.lbActual_Output.Text = "Actual_Output(实际产出)";
            // 
            // lbStart_Time
            // 
            this.lbStart_Time.AutoSize = true;
            this.lbStart_Time.Location = new System.Drawing.Point(256, 91);
            this.lbStart_Time.Name = "lbStart_Time";
            this.lbStart_Time.Size = new System.Drawing.Size(125, 12);
            this.lbStart_Time.TabIndex = 73;
            this.lbStart_Time.Text = "Start_Time(开始时间)";
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Location = new System.Drawing.Point(256, 37);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(65, 12);
            this.lbMO.TabIndex = 72;
            this.lbMO.Text = "MO(工单号)";
            // 
            // lbModel
            // 
            this.lbModel.AutoSize = true;
            this.lbModel.Location = new System.Drawing.Point(256, 10);
            this.lbModel.Name = "lbModel";
            this.lbModel.Size = new System.Drawing.Size(95, 12);
            this.lbModel.TabIndex = 71;
            this.lbModel.Text = "Model(产品型号)";
            // 
            // lbDaily_Plan
            // 
            this.lbDaily_Plan.AutoSize = true;
            this.lbDaily_Plan.Location = new System.Drawing.Point(12, 117);
            this.lbDaily_Plan.Name = "lbDaily_Plan";
            this.lbDaily_Plan.Size = new System.Drawing.Size(125, 12);
            this.lbDaily_Plan.TabIndex = 70;
            this.lbDaily_Plan.Text = "Daily_Plan(每日计划)";
            // 
            // lbOrder_Qty
            // 
            this.lbOrder_Qty.AutoSize = true;
            this.lbOrder_Qty.Location = new System.Drawing.Point(12, 90);
            this.lbOrder_Qty.Name = "lbOrder_Qty";
            this.lbOrder_Qty.Size = new System.Drawing.Size(119, 12);
            this.lbOrder_Qty.TabIndex = 69;
            this.lbOrder_Qty.Text = "Order_Qty(订单数量)";
            // 
            // lbIPN
            // 
            this.lbIPN.AutoSize = true;
            this.lbIPN.Location = new System.Drawing.Point(12, 36);
            this.lbIPN.Name = "lbIPN";
            this.lbIPN.Size = new System.Drawing.Size(71, 12);
            this.lbIPN.TabIndex = 68;
            this.lbIPN.Text = "IPN(订单号)";
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.Location = new System.Drawing.Point(12, 9);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(65, 12);
            this.lbLine.TabIndex = 67;
            this.lbLine.Text = "Line(线别)";
            // 
            // btnMethod_Status
            // 
            this.btnMethod_Status.AutoSize = true;
            this.btnMethod_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMethod_Status.Location = new System.Drawing.Point(273, 169);
            this.btnMethod_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMethod_Status.Name = "btnMethod_Status";
            this.btnMethod_Status.Size = new System.Drawing.Size(87, 23);
            this.btnMethod_Status.TabIndex = 66;
            this.btnMethod_Status.Text = "Method(方法)";
            this.btnMethod_Status.UseVisualStyleBackColor = true;
            this.btnMethod_Status.Click += new System.EventHandler(this.btnMethod_Status_Click);
            // 
            // btnMaterial_Status
            // 
            this.btnMaterial_Status.AutoSize = true;
            this.btnMaterial_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaterial_Status.Location = new System.Drawing.Point(174, 169);
            this.btnMaterial_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaterial_Status.Name = "btnMaterial_Status";
            this.btnMaterial_Status.Size = new System.Drawing.Size(99, 23);
            this.btnMaterial_Status.TabIndex = 65;
            this.btnMaterial_Status.Text = "Material(物料)";
            this.btnMaterial_Status.UseVisualStyleBackColor = true;
            this.btnMaterial_Status.Click += new System.EventHandler(this.btnMaterial_Status_Click);
            // 
            // btnMachine_Status
            // 
            this.btnMachine_Status.AutoSize = true;
            this.btnMachine_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMachine_Status.Location = new System.Drawing.Point(81, 169);
            this.btnMachine_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMachine_Status.Name = "btnMachine_Status";
            this.btnMachine_Status.Size = new System.Drawing.Size(93, 23);
            this.btnMachine_Status.TabIndex = 64;
            this.btnMachine_Status.Text = "Machine(机器)";
            this.btnMachine_Status.UseVisualStyleBackColor = true;
            this.btnMachine_Status.Click += new System.EventHandler(this.btnMachine_Status_Click);
            // 
            // btnMan_Status
            // 
            this.btnMan_Status.AutoSize = true;
            this.btnMan_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMan_Status.Location = new System.Drawing.Point(12, 169);
            this.btnMan_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMan_Status.Name = "btnMan_Status";
            this.btnMan_Status.Size = new System.Drawing.Size(69, 23);
            this.btnMan_Status.TabIndex = 63;
            this.btnMan_Status.Text = "Man(人员)";
            this.btnMan_Status.UseVisualStyleBackColor = true;
            this.btnMan_Status.Click += new System.EventHandler(this.btnMan_Status_Click);
            // 
            // tbMO
            // 
            this.tbMO.Location = new System.Drawing.Point(405, 33);
            this.tbMO.Name = "tbMO";
            this.tbMO.Size = new System.Drawing.Size(135, 21);
            this.tbMO.TabIndex = 62;
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(405, 6);
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(135, 21);
            this.tbModel.TabIndex = 61;
            // 
            // tbActual_Output
            // 
            this.tbActual_Output.Location = new System.Drawing.Point(405, 114);
            this.tbActual_Output.Name = "tbActual_Output";
            this.tbActual_Output.Size = new System.Drawing.Size(135, 21);
            this.tbActual_Output.TabIndex = 60;
            // 
            // tbDaily_Plan
            // 
            this.tbDaily_Plan.Location = new System.Drawing.Point(143, 114);
            this.tbDaily_Plan.Name = "tbDaily_Plan";
            this.tbDaily_Plan.Size = new System.Drawing.Size(107, 21);
            this.tbDaily_Plan.TabIndex = 59;
            this.tbDaily_Plan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDaily_Plan_KeyPress);
            // 
            // tbOrder_Qty
            // 
            this.tbOrder_Qty.Location = new System.Drawing.Point(143, 87);
            this.tbOrder_Qty.Name = "tbOrder_Qty";
            this.tbOrder_Qty.Size = new System.Drawing.Size(107, 21);
            this.tbOrder_Qty.TabIndex = 58;
            // 
            // tbIPN
            // 
            this.tbIPN.Location = new System.Drawing.Point(143, 33);
            this.tbIPN.Name = "tbIPN";
            this.tbIPN.Size = new System.Drawing.Size(107, 21);
            this.tbIPN.TabIndex = 57;
            // 
            // tbLine
            // 
            this.tbLine.Location = new System.Drawing.Point(143, 6);
            this.tbLine.Name = "tbLine";
            this.tbLine.Size = new System.Drawing.Size(107, 21);
            this.tbLine.TabIndex = 56;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(111, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Cancel(取消)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.Location = new System.Drawing.Point(12, 208);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 23);
            this.btnConfirm.TabIndex = 54;
            this.btnConfirm.Text = "Confirm(确认)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // SMTEdit
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 240);
            this.Controls.Add(this.tbPN);
            this.Controls.Add(this.lbPN);
            this.Controls.Add(this.dtpStart_Time);
            this.Controls.Add(this.lbActual_Output);
            this.Controls.Add(this.lbStart_Time);
            this.Controls.Add(this.lbMO);
            this.Controls.Add(this.lbModel);
            this.Controls.Add(this.lbDaily_Plan);
            this.Controls.Add(this.lbOrder_Qty);
            this.Controls.Add(this.lbIPN);
            this.Controls.Add(this.lbLine);
            this.Controls.Add(this.btnMethod_Status);
            this.Controls.Add(this.btnMaterial_Status);
            this.Controls.Add(this.btnMachine_Status);
            this.Controls.Add(this.btnMan_Status);
            this.Controls.Add(this.tbMO);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbActual_Output);
            this.Controls.Add(this.tbDaily_Plan);
            this.Controls.Add(this.tbOrder_Qty);
            this.Controls.Add(this.tbIPN);
            this.Controls.Add(this.tbLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMTEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTEdit";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SMTEdit_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPN;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.DateTimePicker dtpStart_Time;
        private System.Windows.Forms.Label lbActual_Output;
        private System.Windows.Forms.Label lbStart_Time;
        private System.Windows.Forms.Label lbMO;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbDaily_Plan;
        private System.Windows.Forms.Label lbOrder_Qty;
        private System.Windows.Forms.Label lbIPN;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.Button btnMethod_Status;
        private System.Windows.Forms.Button btnMaterial_Status;
        private System.Windows.Forms.Button btnMachine_Status;
        private System.Windows.Forms.Button btnMan_Status;
        private System.Windows.Forms.TextBox tbMO;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.TextBox tbActual_Output;
        private System.Windows.Forms.TextBox tbDaily_Plan;
        private System.Windows.Forms.TextBox tbOrder_Qty;
        private System.Windows.Forms.TextBox tbIPN;
        private System.Windows.Forms.TextBox tbLine;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;

    }
}