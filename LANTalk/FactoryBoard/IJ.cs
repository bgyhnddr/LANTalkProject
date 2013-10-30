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
using DLLFullPrint;
using System.Net;

namespace FactoryBoard
{
    public partial class IJ : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Client _client;


        public IJ(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }

        private void IJ_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Init();
        }
        
        private void IJ_Shown(object sender, EventArgs e)
        {
            Connect();
        }

        private void Init()
        {
            InitMainTable();
            InitDepartment();
            RefreshOfferTable();
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\IJ";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
        }

        private void Connect()
        {
            try
            {
                var config = Global.LoadConfig();
                _client = new Client();
                _client.ConnectServer(
                    IPAddress.Parse(config.Rows[0][Global.ASS_STRING].ToString()),
                    int.Parse(config.Rows[0][Global.PORT_STRING].ToString()),
                    ConnectCallback,
                    ReceiveCallback,
                    null,
                    ErrorCallback);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务失败：" + ex.Message, "错误");
                ReturnTitle();
            }
        }

        private void ConnectCallback()
        {
            btnConnect.Text = "Connected(已连接)";
            btnConnect.Enabled = false;
            btnOffer.Enabled = true;
        }

        private void ErrorCallback(Exception ex)
        {
            if (!Return)
            {
                btnConnect.Text = "Connect(连接)";
                btnConnect.Enabled = true;
                btnOffer.Enabled = false;
            }
        }

        private void ReceiveCallback(IPAddress ip, string content)
        {
            try
            {
                var contents = content.Split(' ');
                var mode = contents[0];
                var fromip = contents[1];
                var toip = contents[2];
                var message = string.Empty;
                var messageindex = content.LastIndexOf(contents[2]) + contents[2].Length;
                if (messageindex < content.Length)
                {
                    message = content.Substring(messageindex + 1);
                }
                switch ((Mode)Enum.Parse(typeof(Mode), mode))
                {
                    case Mode.SendOrder:
                        var department = GetDepartment(fromip);
                        if (department != null)
                        {
                            department.OrderList = CSVHelper.ReadTable(message);
                        }
                        RefreshOfferTable();
                        SendOfferTable();
                        break;
                }
            }
            catch
            {
            }
        }

        

        private void ConnectBtnTips(string message)
        {

        }

        private void InitMainTable()
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
        }

        private void RefreshOfferTable()
        {
            dglOffer.DataSource = GetOfferTable();
        }

        private void SendOfferTable()
        {
            foreach (var department in DepartmentList)
            {
                var content = Mode.SendOrder.ToString();
                content += " " + _client.ClientIP.ToString();
                content += " " + department.IP;
                content += " " + CSVHelper.MakeCSV(department.OrderList);

                _client.SendContent(content);
            }
        }

        private DataTable GetOfferTable()
        {
            var table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MOA", typeof(string));
            table.Columns.Add("P/N", typeof(string));
            table.Columns.Add("Requset_Qtr", typeof(string));
            table.Columns.Add("Request_Time", typeof(string));
            table.Columns.Add("Remarks", typeof(string));

            foreach (DataRow row in DepartmentList[0].OrderList.Rows)
            {
                var newRow = table.NewRow();
                if (row["Remarks"].ToString() == Global.UnKnown)
                {
                    row["Remarks"] = Global.Wait;
                }
                newRow["Department"] = DepartmentList[0].Name;
                newRow["Line"] = row["Line"];
                newRow["Model"] = row["Model"];
                newRow["IPN"] = row["IPN"];
                newRow["MOA"] = row["MOA"];
                newRow["P/N"] = row["P/N"];
                newRow["Requset_Qtr"] = row["Requset_Qtr"];
                newRow["Request_Time"] = row["Request_Time"];
                newRow["Remarks"] = row["Remarks"];
                table.Rows.Add(newRow);
            }


            foreach (DataRow row in DepartmentList[1].OrderList.Rows)
            {
                var newRow = table.NewRow();
                if (row["Remarks"].ToString() == Global.UnKnown)
                {
                    row["Remarks"] = Global.Wait;
                }
                newRow["Department"] = DepartmentList[0].Name;
                newRow["Line"] = string.Empty;
                newRow["Model"] = row["Model"];
                newRow["IPN"] = row["IPN"];
                newRow["MOA"] = row["MOA"];
                newRow["P/N"] = row["P/N"];
                newRow["Requset_Qtr"] = row["Requset_Qtr"];
                newRow["Request_Time"] = row["Request_Time"];
                newRow["Remarks"] = row["Remarks"];
                table.Rows.Add(newRow);
            }
            return table;
        }

        private void InitDepartment()
        {
            DepartmentList = new List<Department>();

            var table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MOA", typeof(string));
            table.Columns.Add("P/N", typeof(string));
            table.Columns.Add("Requset_Qtr", typeof(string));
            table.Columns.Add("Request_Time", typeof(string));
            table.Columns.Add("Remarks", typeof(string));

            var config = Global.LoadConfig();

            DepartmentList.Add(new Department(config.Rows[0][Global.ASS_STRING].ToString(), Global.ASS, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.SSP_STRING].ToString(), Global.SSP, false, table.Clone()));

        }

        public static Department GetDepartment(string ip)
        {
            var temp = from row in DepartmentList
                       where row.IP == ip
                       select row;
            if (temp.Count() > 0)
            {
                var department = temp.First();
                return department;
            }
            return null;
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
                MainTable.Columns.Add("Man_Status", typeof(string));
                MainTable.Columns.Add("Machine_Status", typeof(string));
                MainTable.Columns.Add("Material_Status", typeof(string));
                MainTable.Columns.Add("Method_Status", typeof(string));
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ReturnTitle();
        }

        private void ReturnTitle()
        {
            Return = true;
            _client.DisConnect();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet dy = new DataSet();
            dy.Tables.Add(IJ.MainTable.Copy());
            MyDLL.TakeOver(dy);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new IJEdit(-1);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SaveFile(IJ.MainTable, Global.IJ_STRING);
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenFile.ShowDialog();
            if (!string.IsNullOrWhiteSpace(ofdOpenFile.FileName))
            {
                MainTable = CSVHelper.ReadCSVToTable(ofdOpenFile.FileName);
                dglMain.DataSource = MainTable.Copy();
            }
        }

        private void IJ_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Return)
            {
                Application.Exit();
            }
            MainPage.Focus();
        }

        private void dglMain_DataSourceChanged(object sender, EventArgs e)
        {
            lock (dglMain)
            {
                if (dglMain.Rows.Count > 0)
                {
                    int row = dglMain.Rows.Count;//得到总行数    
                    int cell = dglMain.Rows[0].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                    {
                        for (int j = 9; j < cell; j++)//得到总列数并在之内循环    
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
        }

        private void dglMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dglMain.CurrentCell != null)
            {
                var form = new IJEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
            }
        }

        private void dglOffer_DataSourceChanged(object sender, EventArgs e)
        {
            lock (dglOffer)
            {
                if (dglOffer.Rows.Count > 0)
                {
                    int row = dglOffer.Rows.Count;//得到总行数    
                    int cell = dglOffer.Rows[0].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                    {
                        for (int j = 8; j < cell; j++)//得到总列数并在之内循环    
                        {
                            if (dglOffer.Rows[i].Cells[j].Value != null)
                            {
                                if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.UnKnown)
                                {
                                    this.dglOffer.Rows[i].Cells[j].Style.BackColor = Color.White;
                                    this.dglOffer.Rows[i].Cells[j].Value = string.Empty;
                                }
                                else if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.Revoke)
                                {
                                    this.dglOffer.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                                    this.dglOffer.Rows[i].Cells[j].Value = string.Empty;
                                }
                                else if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.Wait)
                                {
                                    this.dglOffer.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                    this.dglOffer.Rows[i].Cells[j].Value = string.Empty;
                                }
                                else if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.Sending)
                                {
                                    this.dglOffer.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                                    this.dglOffer.Rows[i].Cells[j].Value = string.Empty;
                                }
                                else if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.Receive)
                                {
                                    this.dglOffer.Rows[i].Cells[j].Style.BackColor = Color.GreenYellow;
                                    this.dglOffer.Rows[i].Cells[j].Value = string.Empty;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < this.dglOffer.Columns.Count; i++)
                    {
                        this.dglOffer.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
        }

        private void btnOffer_Click(object sender, EventArgs e)
        {
            Offer();
        }

        private void Offer()
        {
            var index = dglOffer.CurrentCell.RowIndex;
            if (dglOffer.CurrentCell.RowIndex >= 0)
            {
                if (index < DepartmentList[0].OrderList.Rows.Count)
                {
                    if (DepartmentList[0].OrderList.Rows[index]["Remarks"] == Global.Wait)
                    {
                        DepartmentList[0].OrderList.Rows[index]["Remarks"] = Global.Sending;
                    }
                }
                else
                {
                    if (DepartmentList[1].OrderList.Rows[index]["Remarks"] == Global.Wait)
                    {
                        index = index - DepartmentList[0].OrderList.Rows.Count;
                        DepartmentList[1].OrderList.Rows[index]["Remarks"] = Global.Sending;
                    }
                }
                RefreshOfferTable();
                SendOfferTable();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
        }

    }
}
