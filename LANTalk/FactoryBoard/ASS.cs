using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLLFullPrint;

namespace FactoryBoard
{
    public partial class ASS : Form
    {
        public static DataTable MainTable;

        public ASS()
        {
            InitializeComponent();
        }
        
        private void ASS_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Init();
        }

        private void Init()
        {
            InitMainTable();
        }

        private void InitMainTable()
        {
            MainTable = new DataTable();
            MainTable.Columns.Add("Line", typeof(string));
            MainTable.Columns.Add("Model", typeof(string));
            MainTable.Columns.Add("IPN", typeof(string));
            MainTable.Columns.Add("MOA", typeof(string));
            MainTable.Columns.Add("Order_Qty", typeof(string));
            MainTable.Columns.Add("Start_Time", typeof(string));
            MainTable.Columns.Add("Daily_Plan", typeof(string));
            MainTable.Columns.Add("Actual_Output", typeof(string));
            MainTable.Columns.Add("Man", typeof(string));
            MainTable.Columns.Add("Machine", typeof(string));
            MainTable.Columns.Add("Material", typeof(string));
            MainTable.Columns.Add("Method", typeof(string));


            var row = MainTable.NewRow();
            row["Line"] = "C501";
            row["Model"] = "1";
            row["IPN"] = "1";
            row["MOA"] = "1";
            row["Order_Qty"] = "1";
            row["Start_Time"] = "1";
            row["Daily_Plan"] = "1";
            row["Actual_Output"] = "1";
            row["Man"] = "1";
            row["Machine"] = "1";
            row["Material"] = "1";
            row["Method"] = "1";
            MainTable.Rows.Add(row);
            row = MainTable.NewRow();
            row["Line"] = "1";
            row["Model"] = "1";
            row["IPN"] = "1";
            row["MOA"] = "1";
            row["Order_Qty"] = "1";
            row["Start_Time"] = "1";
            row["Daily_Plan"] = "1";
            row["Actual_Output"] = "1";
            row["Man"] = "1";
            row["Machine"] = "1";
            row["Material"] = "1";
            row["Method"] = "1";
            MainTable.Rows.Add(row);

            dataGridView1.DataSource = MainTable.Copy();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataRow dr;
            //设置列表头 
            foreach (DataGridViewColumn headerCell in dataGridView1.Columns)
            {
                dt.Columns.Add(headerCell.HeaderText);
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                dr = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dr[i] = item.Cells[i].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            DataSet dy = new DataSet();
            dy.Tables.Add(dt);
            MyDLL.TakeOver(dy);
        }
    }
}
