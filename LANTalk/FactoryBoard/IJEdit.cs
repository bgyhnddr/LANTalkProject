using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FactoryBoard
{
    public partial class IJEdit : Form
    {
        private bool ADD = true;
        private int RowIndex = -1;
        public IJEdit(int rowIndex)
        {
            InitializeComponent();
            btnMan_Status.BackColor = btnMachine_Status.BackColor = btnMaterial_Status.BackColor = btnMethod_Status.BackColor = Color.GreenYellow;


            if (rowIndex >= 0)
            {
                ADD = false;
                RowIndex = rowIndex;
                tbMachine.ReadOnly = true;
                LoadData(IJ.MainTable.Rows[rowIndex]);
            }
        }

        private void LoadData(DataRow row)
        {

            tbMachine.Text = row["Machine"].ToString();
            tbMould.Text = row["Mould"].ToString();
            tbMaterial.Text = row["Material"].ToString();
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
            if (tbMachine.Text.Trim() == string.Empty ||
                tbMould.Text.Trim() == string.Empty ||
                tbMaterial.Text.Trim() == string.Empty ||
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
                var row = IJ.MainTable.NewRow();
                row["Machine"] = tbMachine.Text;
                row["Mould"] = tbMould.Text;
                row["Material"] = tbMaterial.Text;
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

                IJ.MainTable.Rows.Add(row);
            }
            else
            {
                var row = IJ.MainTable.Rows[RowIndex];
                row["Machine"] = tbMachine.Text;
                row["Mould"] = tbMould.Text;
                row["Material"] = tbMaterial.Text;
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
                Global.SaveFile(IJ.MainTable, Global.IJ_STRING);
                MessageBox.Show("Saved");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail：" + ex.Message);
                if (ADD)
                {
                    IJ.MainTable.Rows.RemoveAt(IJ.MainTable.Rows.Count - 1);
                }
                else
                {
                    IJ.MainTable.Rows.RemoveAt(RowIndex);
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

        private void IJEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.btnConfirm_Click(sender, e);//触发button事件
            }
        }
    }
}
