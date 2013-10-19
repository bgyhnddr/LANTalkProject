using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LANTalk.Core;

namespace FactoryBoard
{
    public partial class IJ : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public static string CurrentOrder;
        public Main MainPage;
        private bool Return;

        public IJ()
        {
            InitializeComponent();
        }

        private void IJ_Load(object sender, EventArgs e)
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
            path += "\\LANTalk\\SaveFile\\IJ";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
        }

        private void InitMainTable()
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
        }

        private void LoadCurrentFile()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\IJ\\current.csv";
            if (File.Exists(path))
            {
                MainTable = CSVHelper.ReadCSVToTable(path);
            }
            else
            {
                MainTable = new DataTable();
                MainTable.Columns.Add("Machine", typeof(string));
                MainTable.Columns.Add("Mould", typeof(string));
                MainTable.Columns.Add("Material", typeof(string));
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Return = true;
            MainPage.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                MainTable.Rows.RemoveAt(dglMain.CurrentCell.RowIndex);
            }
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dglMain.CurrentCell != null)
            {
                var form = new IJEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
            }
        }
    }
}
