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
        public static List<Department> DepartmentList;
        public Main MainPage;
        private bool Return;

        public ASS(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
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
            lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
        }

        private void InitDepartment()
        {
            DepartmentList = new List<Department>();


        }

        private void InitMainTable()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\current.csv";
            LoadCurrentFile();



            dglMain.DataSource = MainTable.Copy();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet dy = new DataSet();
            dy.Tables.Add(ASS.MainTable.Copy());
            MyDLL.TakeOver(dy);
        }

        private void ASS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Return)
            {
                Application.Exit();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dglMain.CurrentCell != null)
            {
                var form = new ASSEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
            }
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ASSEdit(-1);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }

        private void dglMain_DataSourceChanged(object sender, EventArgs e)
        {
            if (dglMain.Rows.Count > 0)
            {
                int row = dglMain.Rows.Count;//得到总行数    
                int cell = dglMain.Rows[0].Cells.Count;//得到总列数    
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                MainTable.Rows.RemoveAt(dglMain.CurrentCell.RowIndex);
            }
            dglMain.DataSource = MainTable.Copy();
        }

        private void dglMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var form = new ASSEdit(dglMain.CurrentCell.RowIndex);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenFile.ShowDialog();
            MainTable = CSVHelper.ReadCSVToTable(ofdOpenFile.FileName);
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
        }


        private void LoadCurrentFile()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\current.csv";
            if (File.Exists(path))
            {
                MainTable = CSVHelper.ReadCSVToTable(path);
            }
            else
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
            }
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnIJ_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Return = true;
            MainPage.Show();
            this.Close();
        }
    }
}
