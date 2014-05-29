namespace FactoryBoard
{
    partial class IJEdit
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
            this.lbActual_Output = new System.Windows.Forms.Label();
            this.lbStart_Time = new System.Windows.Forms.Label();
            this.lbMO = new System.Windows.Forms.Label();
            this.lbMould = new System.Windows.Forms.Label();
            this.lbDaily_Plan = new System.Windows.Forms.Label();
            this.lbOrder_Qty = new System.Windows.Forms.Label();
            this.lbIPN = new System.Windows.Forms.Label();
            this.lbMachine = new System.Windows.Forms.Label();
            this.btnMethod_Status = new System.Windows.Forms.Button();
            this.btnMaterial_Status = new System.Windows.Forms.Button();
            this.btnMachine_Status = new System.Windows.Forms.Button();
            this.btnMan_Status = new System.Windows.Forms.Button();
            this.tbMO = new System.Windows.Forms.TextBox();
            this.tbMould = new System.Windows.Forms.TextBox();
            this.tbActual_Output = new System.Windows.Forms.TextBox();
            this.tbDaily_Plan = new System.Windows.Forms.TextBox();
            this.tbOrder_Qty = new System.Windows.Forms.TextBox();
            this.tbIPN = new System.Windows.Forms.TextBox();
            this.tbMachine = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbMaterial = new System.Windows.Forms.Label();
            this.tbMaterial = new System.Windows.Forms.TextBox();
            this.dtpStart_Time = new System.Windows.Forms.DateTimePicker();
            this.lbPN = new System.Windows.Forms.Label();
            this.tbPN = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.numOutput = new System.Windows.Forms.NumericUpDown();
            this.lbCurrentOutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // lbActual_Output
            // 
            this.lbActual_Output.AutoSize = true;
            this.lbActual_Output.Location = new System.Drawing.Point(256, 117);
            this.lbActual_Output.Name = "lbActual_Output";
            this.lbActual_Output.Size = new System.Drawing.Size(143, 12);
            this.lbActual_Output.TabIndex = 46;
            this.lbActual_Output.Text = "Actual_Output(实际产出)";
            // 
            // lbStart_Time
            // 
            this.lbStart_Time.AutoSize = true;
            this.lbStart_Time.Location = new System.Drawing.Point(256, 90);
            this.lbStart_Time.Name = "lbStart_Time";
            this.lbStart_Time.Size = new System.Drawing.Size(125, 12);
            this.lbStart_Time.TabIndex = 45;
            this.lbStart_Time.Text = "Start_Time(开始时间)";
            // 
            // lbMO
            // 
            this.lbMO.AutoSize = true;
            this.lbMO.Location = new System.Drawing.Point(256, 63);
            this.lbMO.Name = "lbMO";
            this.lbMO.Size = new System.Drawing.Size(65, 12);
            this.lbMO.TabIndex = 44;
            this.lbMO.Text = "MO(工单号)";
            // 
            // lbMould
            // 
            this.lbMould.AutoSize = true;
            this.lbMould.Location = new System.Drawing.Point(256, 9);
            this.lbMould.Name = "lbMould";
            this.lbMould.Size = new System.Drawing.Size(71, 12);
            this.lbMould.TabIndex = 43;
            this.lbMould.Text = "Mould(型号)";
            // 
            // lbDaily_Plan
            // 
            this.lbDaily_Plan.AutoSize = true;
            this.lbDaily_Plan.Location = new System.Drawing.Point(12, 117);
            this.lbDaily_Plan.Name = "lbDaily_Plan";
            this.lbDaily_Plan.Size = new System.Drawing.Size(125, 12);
            this.lbDaily_Plan.TabIndex = 42;
            this.lbDaily_Plan.Text = "Daily_Plan(每日计划)";
            // 
            // lbOrder_Qty
            // 
            this.lbOrder_Qty.AutoSize = true;
            this.lbOrder_Qty.Location = new System.Drawing.Point(12, 90);
            this.lbOrder_Qty.Name = "lbOrder_Qty";
            this.lbOrder_Qty.Size = new System.Drawing.Size(119, 12);
            this.lbOrder_Qty.TabIndex = 41;
            this.lbOrder_Qty.Text = "Order_Qty(订单数量)";
            // 
            // lbIPN
            // 
            this.lbIPN.AutoSize = true;
            this.lbIPN.Location = new System.Drawing.Point(256, 36);
            this.lbIPN.Name = "lbIPN";
            this.lbIPN.Size = new System.Drawing.Size(71, 12);
            this.lbIPN.TabIndex = 40;
            this.lbIPN.Text = "IPN(订单号)";
            // 
            // lbMachine
            // 
            this.lbMachine.AutoSize = true;
            this.lbMachine.Location = new System.Drawing.Point(12, 9);
            this.lbMachine.Name = "lbMachine";
            this.lbMachine.Size = new System.Drawing.Size(83, 12);
            this.lbMachine.TabIndex = 39;
            this.lbMachine.Text = "Machine(机器)";
            // 
            // btnMethod_Status
            // 
            this.btnMethod_Status.AutoSize = true;
            this.btnMethod_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMethod_Status.Location = new System.Drawing.Point(271, 143);
            this.btnMethod_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMethod_Status.Name = "btnMethod_Status";
            this.btnMethod_Status.Size = new System.Drawing.Size(87, 23);
            this.btnMethod_Status.TabIndex = 38;
            this.btnMethod_Status.Text = "Method(方法)";
            this.btnMethod_Status.UseVisualStyleBackColor = true;
            this.btnMethod_Status.Click += new System.EventHandler(this.btnMethod_Click);
            // 
            // btnMaterial_Status
            // 
            this.btnMaterial_Status.AutoSize = true;
            this.btnMaterial_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaterial_Status.Location = new System.Drawing.Point(172, 143);
            this.btnMaterial_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaterial_Status.Name = "btnMaterial_Status";
            this.btnMaterial_Status.Size = new System.Drawing.Size(99, 23);
            this.btnMaterial_Status.TabIndex = 37;
            this.btnMaterial_Status.Text = "Material(物料)";
            this.btnMaterial_Status.UseVisualStyleBackColor = true;
            this.btnMaterial_Status.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnMachine_Status
            // 
            this.btnMachine_Status.AutoSize = true;
            this.btnMachine_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMachine_Status.Location = new System.Drawing.Point(80, 143);
            this.btnMachine_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMachine_Status.Name = "btnMachine_Status";
            this.btnMachine_Status.Size = new System.Drawing.Size(93, 23);
            this.btnMachine_Status.TabIndex = 36;
            this.btnMachine_Status.Text = "Machine(机器)";
            this.btnMachine_Status.UseVisualStyleBackColor = true;
            this.btnMachine_Status.Click += new System.EventHandler(this.btnMachine_Click);
            // 
            // btnMan_Status
            // 
            this.btnMan_Status.AutoSize = true;
            this.btnMan_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMan_Status.Location = new System.Drawing.Point(11, 143);
            this.btnMan_Status.Margin = new System.Windows.Forms.Padding(0);
            this.btnMan_Status.Name = "btnMan_Status";
            this.btnMan_Status.Size = new System.Drawing.Size(69, 23);
            this.btnMan_Status.TabIndex = 35;
            this.btnMan_Status.Text = "Man(人员)";
            this.btnMan_Status.UseVisualStyleBackColor = true;
            this.btnMan_Status.Click += new System.EventHandler(this.btnMan_Click);
            // 
            // tbMO
            // 
            this.tbMO.Location = new System.Drawing.Point(405, 60);
            this.tbMO.Name = "tbMO";
            this.tbMO.Size = new System.Drawing.Size(135, 21);
            this.tbMO.TabIndex = 34;
            // 
            // tbMould
            // 
            this.tbMould.Location = new System.Drawing.Point(405, 6);
            this.tbMould.Name = "tbMould";
            this.tbMould.Size = new System.Drawing.Size(135, 21);
            this.tbMould.TabIndex = 33;
            // 
            // tbActual_Output
            // 
            this.tbActual_Output.Location = new System.Drawing.Point(405, 114);
            this.tbActual_Output.Name = "tbActual_Output";
            this.tbActual_Output.Size = new System.Drawing.Size(135, 21);
            this.tbActual_Output.TabIndex = 32;
            // 
            // tbDaily_Plan
            // 
            this.tbDaily_Plan.Location = new System.Drawing.Point(143, 114);
            this.tbDaily_Plan.Name = "tbDaily_Plan";
            this.tbDaily_Plan.Size = new System.Drawing.Size(107, 21);
            this.tbDaily_Plan.TabIndex = 30;
            this.tbDaily_Plan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDaily_Plan_KeyPress);
            // 
            // tbOrder_Qty
            // 
            this.tbOrder_Qty.Location = new System.Drawing.Point(143, 87);
            this.tbOrder_Qty.Name = "tbOrder_Qty";
            this.tbOrder_Qty.Size = new System.Drawing.Size(107, 21);
            this.tbOrder_Qty.TabIndex = 29;
            // 
            // tbIPN
            // 
            this.tbIPN.Location = new System.Drawing.Point(405, 33);
            this.tbIPN.Name = "tbIPN";
            this.tbIPN.Size = new System.Drawing.Size(135, 21);
            this.tbIPN.TabIndex = 28;
            // 
            // tbMachine
            // 
            this.tbMachine.Location = new System.Drawing.Point(143, 6);
            this.tbMachine.Name = "tbMachine";
            this.tbMachine.Size = new System.Drawing.Size(107, 21);
            this.tbMachine.TabIndex = 27;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(110, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel(取消)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.Location = new System.Drawing.Point(11, 180);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 23);
            this.btnConfirm.TabIndex = 25;
            this.btnConfirm.Text = "Confirm(确认)";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbMaterial
            // 
            this.lbMaterial.AutoSize = true;
            this.lbMaterial.Location = new System.Drawing.Point(12, 36);
            this.lbMaterial.Name = "lbMaterial";
            this.lbMaterial.Size = new System.Drawing.Size(89, 12);
            this.lbMaterial.TabIndex = 48;
            this.lbMaterial.Text = "Material(物料)";
            // 
            // tbMaterial
            // 
            this.tbMaterial.Location = new System.Drawing.Point(143, 33);
            this.tbMaterial.Name = "tbMaterial";
            this.tbMaterial.Size = new System.Drawing.Size(107, 21);
            this.tbMaterial.TabIndex = 47;
            // 
            // dtpStart_Time
            // 
            this.dtpStart_Time.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpStart_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Time.Location = new System.Drawing.Point(405, 87);
            this.dtpStart_Time.Name = "dtpStart_Time";
            this.dtpStart_Time.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpStart_Time.Size = new System.Drawing.Size(135, 21);
            this.dtpStart_Time.TabIndex = 49;
            // 
            // lbPN
            // 
            this.lbPN.AutoSize = true;
            this.lbPN.Location = new System.Drawing.Point(14, 63);
            this.lbPN.Name = "lbPN";
            this.lbPN.Size = new System.Drawing.Size(59, 12);
            this.lbPN.TabIndex = 50;
            this.lbPN.Text = "P/N(品号)";
            // 
            // tbPN
            // 
            this.tbPN.Location = new System.Drawing.Point(143, 60);
            this.tbPN.Name = "tbPN";
            this.tbPN.Size = new System.Drawing.Size(107, 21);
            this.tbPN.TabIndex = 51;
            // 
            // btnInput
            // 
            this.btnInput.AutoSize = true;
            this.btnInput.Location = new System.Drawing.Point(447, 166);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(93, 23);
            this.btnInput.TabIndex = 54;
            this.btnInput.Text = "输入（Input）";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // numOutput
            // 
            this.numOutput.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numOutput.Location = new System.Drawing.Point(393, 166);
            this.numOutput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numOutput.Name = "numOutput";
            this.numOutput.Size = new System.Drawing.Size(51, 21);
            this.numOutput.TabIndex = 53;
            // 
            // lbCurrentOutput
            // 
            this.lbCurrentOutput.AutoSize = true;
            this.lbCurrentOutput.Location = new System.Drawing.Point(391, 151);
            this.lbCurrentOutput.Name = "lbCurrentOutput";
            this.lbCurrentOutput.Size = new System.Drawing.Size(149, 12);
            this.lbCurrentOutput.TabIndex = 52;
            this.lbCurrentOutput.Text = "Current Output(当前产出)";
            // 
            // IJEdit
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 218);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.numOutput);
            this.Controls.Add(this.lbCurrentOutput);
            this.Controls.Add(this.tbPN);
            this.Controls.Add(this.lbPN);
            this.Controls.Add(this.dtpStart_Time);
            this.Controls.Add(this.lbMaterial);
            this.Controls.Add(this.tbMaterial);
            this.Controls.Add(this.lbActual_Output);
            this.Controls.Add(this.lbStart_Time);
            this.Controls.Add(this.lbMO);
            this.Controls.Add(this.lbMould);
            this.Controls.Add(this.lbDaily_Plan);
            this.Controls.Add(this.lbOrder_Qty);
            this.Controls.Add(this.lbIPN);
            this.Controls.Add(this.lbMachine);
            this.Controls.Add(this.btnMethod_Status);
            this.Controls.Add(this.btnMaterial_Status);
            this.Controls.Add(this.btnMachine_Status);
            this.Controls.Add(this.btnMan_Status);
            this.Controls.Add(this.tbMO);
            this.Controls.Add(this.tbMould);
            this.Controls.Add(this.tbActual_Output);
            this.Controls.Add(this.tbDaily_Plan);
            this.Controls.Add(this.tbOrder_Qty);
            this.Controls.Add(this.tbIPN);
            this.Controls.Add(this.tbMachine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IJEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IJEdit";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IJEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbActual_Output;
        private System.Windows.Forms.Label lbStart_Time;
        private System.Windows.Forms.Label lbMO;
        private System.Windows.Forms.Label lbMould;
        private System.Windows.Forms.Label lbDaily_Plan;
        private System.Windows.Forms.Label lbOrder_Qty;
        private System.Windows.Forms.Label lbIPN;
        private System.Windows.Forms.Label lbMachine;
        private System.Windows.Forms.Button btnMethod_Status;
        private System.Windows.Forms.Button btnMaterial_Status;
        private System.Windows.Forms.Button btnMachine_Status;
        private System.Windows.Forms.Button btnMan_Status;
        private System.Windows.Forms.TextBox tbMO;
        private System.Windows.Forms.TextBox tbMould;
        private System.Windows.Forms.TextBox tbActual_Output;
        private System.Windows.Forms.TextBox tbDaily_Plan;
        private System.Windows.Forms.TextBox tbOrder_Qty;
        private System.Windows.Forms.TextBox tbIPN;
        private System.Windows.Forms.TextBox tbMachine;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbMaterial;
        private System.Windows.Forms.TextBox tbMaterial;
        private System.Windows.Forms.DateTimePicker dtpStart_Time;
        private System.Windows.Forms.Label lbPN;
        private System.Windows.Forms.TextBox tbPN;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.NumericUpDown numOutput;
        private System.Windows.Forms.Label lbCurrentOutput;

    }
}