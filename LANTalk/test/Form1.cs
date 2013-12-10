using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLLFullPrint;

namespace test
{
    public partial class Form1 : Form
    {
        public DataTable labelTable = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            
            labelTable.Columns.Add("Line", typeof(string));
            labelTable.Columns.Add("Man", typeof(string));
            labelTable.Columns.Add("Machine", typeof(string));
            var row = labelTable.NewRow();
            row["Line"] = "1";
            row["Man"] = "1";
            row["Machine"] = "1";
            labelTable.Rows.Add(row);
            row = labelTable.NewRow();
            row["Line"] = "1";
            row["Man"] = "0";
            row["Machine"] = "1";
            labelTable.Rows.Add(row);

            dataGridView1.DataSource = labelTable.Copy();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                for (int j = 1; j < cell; j++)//得到总列数并在之内循环    
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (this.dataGridView1.Rows[i].Cells[j].Value.ToString() == "0")
                        {
                            this.dataGridView1.Rows[i].Cells[cell - 1].Style.BackColor = Color.Red;
                            this.dataGridView1.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                    }
                }
            }  
        }

        private void button1_Click(object sender, EventArgs e)
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
