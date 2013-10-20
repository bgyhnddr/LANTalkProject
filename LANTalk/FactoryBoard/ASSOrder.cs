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

        public ASSOrder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            var department = ASS.GetCurrentDepartment();
            if (department!=null)
            {
                var row = department.OrderList.NewRow();
                row["Line"] = tbLine.Text;
                row["Model"] = tbModel.Text;
                row["IPN"] = tbIPN.Text;
                row["MOA"] = tbMOA.Text;
                row["P/N"] = tbPN.Text;
                row["Requset_Qtr"] = tbRequset_Qtr.Text;
                row["Request_Time"] = tbRequest_Time.Text;
                row["Remarks"] = Global.UnKnown;

                department.OrderList.Rows.Add(row);
            }


            this.Close();
        }
    }
}
