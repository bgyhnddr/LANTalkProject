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
    public partial class ASSEdit : Form
    {
        private bool ADD = true;

        public ASSEdit(int rowIndex)
        {
            InitializeComponent();

            btnMan.BackColor = btnMachine.BackColor = btnMaterial.BackColor = btnMethod.BackColor = Color.GreenYellow;


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
            tbMOA.Text = row["MOA"].ToString();
            tbOrder_Qty.Text = row["Order_Qty"].ToString();
            tbStart_Time.Text = row["Start_Time"].ToString();
            tbDaily_Plan.Text = row["Daily_Plan"].ToString();
            tbActual_Output.Text = row["Actual_Output"].ToString();

            btnMan.BackColor = row["Man"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMachine.BackColor = row["Machine"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMaterial.BackColor = row["Material"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
            btnMethod.BackColor = row["Method"].ToString() == Global.Normal ? Color.GreenYellow : Color.Red;
        }

        private void btnMan_Click(object sender, EventArgs e)
        {

            btnMan.BackColor = btnMan.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMachine_Click(object sender, EventArgs e)
        {
            btnMachine.BackColor = btnMachine.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            btnMaterial.BackColor = btnMaterial.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
        }

        private void btnMethod_Click(object sender, EventArgs e)
        {
            btnMethod.BackColor = btnMethod.BackColor == Color.GreenYellow ? Color.Red : Color.GreenYellow;
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
                row["MOA"] = tbMOA.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = tbStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man"] = btnMan.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine"] = btnMachine.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material"] = btnMaterial.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method"] = btnMethod.BackColor == Color.Red ? Global.UnNormal : Global.Normal;

                ASS.MainTable.Rows.Add(row);
            }
            else
            {
                var row = ASS.MainTable.Select("Line = '" + tbLine.Text + "'").First();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MOA"] = tbMOA.Text;
                row["Order_Qty"] = tbOrder_Qty.Text;
                row["Start_Time"] = tbStart_Time.Text;
                row["Daily_Plan"] = tbDaily_Plan.Text;
                row["Actual_Output"] = tbActual_Output.Text;
                row["Man"] = btnMan.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Machine"] = btnMachine.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Material"] = btnMaterial.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
                row["Method"] = btnMethod.BackColor == Color.Red ? Global.UnNormal : Global.Normal;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
