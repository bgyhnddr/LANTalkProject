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
    public partial class SSPOrder : Form
    {

        public SSPOrder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbModel.Text.Trim() == string.Empty ||
                tbIPN.Text.Trim() == string.Empty ||
                tbMO.Text.Trim() == string.Empty ||
                tbPN.Text.Trim() == string.Empty ||
                tbRequset_Qty.Text.Trim() == string.Empty ||
                dtpRequest_Time.Text.Trim() == string.Empty)
            {
                MessageBox.Show("所有项均要填写");
                return;
            }

            var department = SSP.GetCurrentDepartment();
            if (department!=null)
            {
                var row = department.OrderList.NewRow();
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MO"] = tbMO.Text;
                row["P/N"] = tbPN.Text;
                row["Requset_Qty"] = tbRequset_Qty.Text;
                row["Request_Time"] = dtpRequest_Time.Text;
                row["Remarks"] = Global.UnKnown;
                department.OrderList.Rows.InsertAt(row, 0);
            }


            this.Close();
        }
    }
}
