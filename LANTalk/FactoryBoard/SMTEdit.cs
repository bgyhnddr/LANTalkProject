﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FactoryBoard
{
    public partial class SMTEdit : Form
    {
        private bool ADD = true;
        private int RowIndex = -1;
        public SMTEdit(int rowIndex)
        {
            InitializeComponent();
            btnMan_Status.BackColor = btnMachine_Status.BackColor = btnMaterial_Status.BackColor = btnMethod_Status.BackColor = Color.GreenYellow;


            if (rowIndex >= 0)
            {
                ADD = false;
                RowIndex = rowIndex;
                tbLine.ReadOnly = true;
                LoadData(SMT.MainTable.Rows[rowIndex]);
            }
        }

        private void LoadData(DataRow row)
        {
            tbLine.Text = row["Line"].ToString();
            tbModel.Text = row["Model"].ToString();
            tbIPN.Text = row["IPN"].ToString();
            tbMO.Text = row["MO"].ToString();
            tbPN.Text = row["P/N"].ToString();
            tbOrder_Qty.Text = row["Order_Qty"].ToString();
            dtpStart_Time.Text = row["Start_Time"].ToString();
            tbDaily_Plan.Text = row["Daily_Plan"].ToString();
            tbActual_Output.Text = row["Actual_Output"].ToString();

            btnMan_Status.BackColor = row["Man_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMachine_Status.BackColor = row["Machine_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMaterial_Status.BackColor = row["Material_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMethod_Status.BackColor = row["Method_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
        }

        private void btnMan_Status_Click(object sender, EventArgs e)
        {
            btnMan_Status.BackColor = btnMan_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMachine_Status_Click(object sender, EventArgs e)
        {
            btnMachine_Status.BackColor = btnMachine_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMaterial_Status_Click(object sender, EventArgs e)
        {
            btnMaterial_Status.BackColor = btnMaterial_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMethod_Status_Click(object sender, EventArgs e)
        {
            btnMethod_Status.BackColor = btnMethod_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbLine.Text.Trim() == string.Empty ||
                tbModel.Text.Trim() == string.Empty ||
                tbIPN.Text.Trim() == string.Empty ||
                tbMO.Text.Trim() == string.Empty ||
                tbPN.Text.Trim() == string.Empty ||
                tbOrder_Qty.Text.Trim() == string.Empty ||
                dtpStart_Time.Text.Trim() == string.Empty ||
                tbDaily_Plan.Text.Trim() == string.Empty ||
                tbActual_Output.Text.Trim() == string.Empty)
            {
                MessageBox.Show("所有项均要填写");
                return;
            }

            if (ADD)
            {
                var row = SMT.MainTable.NewRow();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["P/N"] = tbPN.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = dtpStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man_Status"] = btnMan_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine_Status"] = btnMachine_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material_Status"] = btnMaterial_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method_Status"] = btnMethod_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;

                SMT.MainTable.Rows.Add(row);
            }
            else
            {
                var row = SMT.MainTable.Rows[RowIndex];
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["P/N"] = tbPN.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = dtpStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man_Status"] = btnMan_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine_Status"] = btnMachine_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material_Status"] = btnMaterial_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method_Status"] = btnMethod_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
            }
            try
            {
                Global.SaveFile(SMT.MainTable, Global.SMT_STRING);
                MessageBox.Show("Saved");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail：" + ex.Message);
                if (ADD)
                {
                    SMT.MainTable.Rows.RemoveAt(SMT.MainTable.Rows.Count - 1);
                }
                else
                {
                    SMT.MainTable.Rows.RemoveAt(RowIndex);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDaily_Plan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            } 
        }

        private void SMTEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.btnConfirm_Click(sender, e);//触发button事件
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            var temp = tbActual_Output.Text;

            int output = 0;
            int.TryParse(tbActual_Output.Text, out output);

            int input = (int)numOutput.Value;

            tbActual_Output.Text = (output + input).ToString();
        }
    }
}
