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
    public partial class ASSEdit : Form
    {
        private bool ADD = true;

        public ASSEdit(int rowIndex)
        {
            InitializeComponent();

            btnMan_Status.BackColor = btnMachine_Status.BackColor = btnMaterial_Status.BackColor = btnMethod_Status.BackColor = Color.GreenYellow;


            if (rowIndex >= 0)
            {
                ADD = false;
                tbLine.ReadOnly = true;
                LoadData(ASS.MainTable.Rows[rowIndex]);
            }
        }

        private void LoadData(DataRow row)
        {

            tbLine.Text = row["Line"].ToString();
            tbModel.Text = row["Model"].ToString();
            tbIPN.Text = row["IPN"].ToString();
            tbMO.Text = row["MO"].ToString();
            tbOrder_Qty.Text = row["Order_Qty"].ToString();
            dtpStart_Time.Text = row["Start_Time"].ToString();
            tbDaily_Plan.Text = row["Daily_Plan"].ToString();
            tbActual_Output.Text = row["Actual_Output"].ToString();

            btnMan_Status.BackColor = row["Man_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMachine_Status.BackColor = row["Machine_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMaterial_Status.BackColor = row["Material_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMethod_Status.BackColor = row["Method_Status"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
        }

        private void btnMan_Click(object sender, EventArgs e)
        {

            btnMan_Status.BackColor = btnMan_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMachine_Click(object sender, EventArgs e)
        {
            btnMachine_Status.BackColor = btnMachine_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            btnMaterial_Status.BackColor = btnMaterial_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMethod_Click(object sender, EventArgs e)
        {
            btnMethod_Status.BackColor = btnMethod_Status.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ADD)
            {
                if (ASS.MainTable.Select("Line = '" + tbLine.Text + "'").Length > 0)
                {
                    MessageBox.Show("该生产线已存在，无法新增。");
                    return;
                }
                var row = ASS.MainTable.NewRow();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = dtpStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man_Status"] = btnMan_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine_Status"] = btnMachine_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material_Status"] = btnMaterial_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method_Status"] = btnMethod_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;

                ASS.MainTable.Rows.Add(row);
            }
            else
            {
                var row = ASS.MainTable.Select("Line = '" + tbLine.Text + "'").First();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = dtpStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man_Status"] = btnMan_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine_Status"] = btnMachine_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material_Status"] = btnMaterial_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method_Status"] = btnMethod_Status.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
            }

            this.Close();
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
    }
}
