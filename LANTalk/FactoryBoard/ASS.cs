using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLLFullPrint;
using LANTalk.Core;
using System.IO;

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
            row["Man"] = Global.Normal;
            row["Machine"] = Global.Normal;
            row["Material"] = Global.Normal;
            row["Method"] = Global.Normal;
            MainTable.Rows.Add(row);
            row = MainTable.NewRow();
            row["Line"] = "1";
            row["Model"] = "1";
            row["IPN"] = "1";
            row["MOA"] = "1";
            row["Order_Qty"] = "12";
            row["Start_Time"] = "1";
            row["Daily_Plan"] = "1";
            row["Actual_Output"] = "1";
            row["Man"] = Global.Normal;
            row["Machine"] = Global.Normal;
            row["Material"] = Global.Normal;
            row["Method"] = Global.Normal;
            MainTable.Rows.Add(row);

            dglMain.DataSource = MainTable.Copy();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //System.Data.DataTable dt = new System.Data.DataTable();
            //DataRow dr;
            ////设置列表头 
            //foreach (DataGridViewColumn headerCell in dglMain.Columns)
            //{
            //    dt.Columns.Add(headerCell.HeaderText);
            //}
            //foreach (DataGridViewRow item in dglMain.Rows)
            //{
            //    dr = dt.NewRow();
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        dr[i] = item.Cells[i].Value.ToString();
            //    }
            //    dt.Rows.Add(dr);
            //}
            DataSet dy = new DataSet();
            dy.Tables.Add(ASS.MainTable.Copy());
            MyDLL.TakeOver(dy);
        }

        private void ASS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var form = new ASSEdit(dglMain.CurrentCell.RowIndex);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ASSEdit(-1);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }

        private void dglMain_DataSourceChanged(object sender, EventArgs e)
        {
            int row = dglMain.Rows.Count;//得到总行数    
            int cell = dglMain.Rows[1].Cells.Count;//得到总列数    
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                for (int j = 8; j < cell; j++)//得到总列数并在之内循环    
                {
                    if (dglMain.Rows[i].Cells[j].Value != null)
                    {
                        if (this.dglMain.Rows[i].Cells[j].Value.ToString() == Global.UnNormal)
                        {
                            this.dglMain.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            this.dglMain.Rows[i].Cells[j].Value = string.Empty;
                        }
                        else if (this.dglMain.Rows[i].Cells[j].Value.ToString() == Global.Normal)
                        {
                            this.dglMain.Rows[i].Cells[j].Style.BackColor = Color.GreenYellow;
                            this.dglMain.Rows[i].Cells[j].Value = string.Empty;
                        }
                    }
                }
            }
            for (int i = 0; i < this.dglMain.Columns.Count; i++)
            {
                this.dglMain.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SaveFile(ASS.MainTable);
                MessageBox.Show("保存成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }
    }
}
