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
    public partial class ASSOrder : Form
    {
        private int RowIndex = -1;

        public ASSOrder(int rowIndex)
        {
            InitializeComponent();

            if (rowIndex >= 0)
            {
                RowIndex = rowIndex;
                LoadData(ASS.GetCurrentDepartment().OrderList.Rows[rowIndex]);
            }
        }

        private void LoadData(DataRow row)
        {
            tbLine.Text = row["Line"].ToString();
            tbModel.Text = row["Model"].ToString();
            tbIPN.Text = row["IPN"].ToString();
            tbMO.Text = row["MO"].ToString();
            tbProcess.Text = row["Process"].ToString();
            tbPN.Text = row["P/N"].ToString();
            tbRequset_Qty.Text = row["Requset_Qty"].ToString();
            dtpRequest_Time.Text = row["Request_Time"].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbLine.Text.Trim() == string.Empty ||
                tbModel.Text.Trim() == string.Empty ||
                tbIPN.Text.Trim() == string.Empty ||
                tbMO.Text.Trim() == string.Empty ||
                tbPN.Text.Trim() == string.Empty ||
                tbRequset_Qty.Text.Trim() == string.Empty ||
                dtpRequest_Time.Text.Trim() == string.Empty)
            {
                MessageBox.Show("未填写完整");
                return;
            }

            var department = ASS.GetCurrentDepartment();
            if (department != null)
            {
                var row = department.OrderList.NewRow();
                row["Guid"] = Guid.NewGuid().ToString();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["Process"] = tbProcess.Text;
                row["P/N"] = tbPN.Text;
                row["Requset_Qty"] = tbRequset_Qty.Text;
                row["Request_Time"] = dtpRequest_Time.Text;
                row["Status"] = Global.UnKnown;
                department.OrderList.Rows.InsertAt(row, 0);
            }


            this.Close();
        }

        private void ASSOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.btnConfirm_Click(sender, e);//触发button事件
            }
        }
    }
}
