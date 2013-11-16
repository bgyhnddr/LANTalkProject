﻿using System;
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
using System.Threading;
using System.Threading.Tasks;

namespace FactoryBoard
{
    public partial class IJ : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Client _client;
        private delegate void RefreshDelegate();//定义委托

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_MAXISIZE = 0xf030;//最小化  
            const int SC_NORMAL = 0xf120;//还原  
            const int SC_DOUBLECLICK = 0xf122;//双击窗体标题栏  
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_MAXISIZE))//最大化  
            {
                return;
            }
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_NORMAL))//还原  
            {
                return;
            }
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_DOUBLECLICK))///双击窗体标题栏  
            {
                return;
            }
            //if (m.Msg == WM_SYSCOMMAND)//用来获取用户触发事件的16进制参数，通过科学计算器转换  
            //{  
            //    int test = (int)m.WParam;  
            //}  
            base.WndProc(ref m);
        }

        public IJ(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }

        private void IJ_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
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
            dglOffer.DataSource = GetOfferTable();
            var time = DateTime.Now;
            lbTime.Text = lbTime2.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
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
                MessageBox.Show("connect error：" + ex.Message, "error");
                ReturnTitle();
            }
        }

        private void ConnectCallback()
        {
            RefreshDelegate refresh = () =>
               {
                   btnConnect.Text = "Connected(已连接)";
                   btnOffer.Enabled = true;
                   if (tabMain.SelectedTab == tagMain)
                   {
                       tabMain.SelectedTab = tagOffer;
                       Task task = new Task(() =>
                       {
                           RefreshDelegate refresh2 = () =>
                           {
                               tabMain.SelectedTab = tagMain;
                           };
                           this.Invoke(refresh2);
                       });
                       task.Start();
                   }
               };
            this.Invoke(refresh);
        }

        private void ErrorCallback(Exception ex)
        {
            RefreshDelegate refresh = () =>
            {
                btnConnect.Text = "Disconnect(未连接)";
                btnOffer.Enabled = false;
                Connect();
            };
            if (!Return)
            {
                this.Invoke(refresh);
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
                            RefreshOfferTable();
                            SendOfferTable();
                        }
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
            Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                RefreshDelegate refresh = () =>
                {
                    LoadCurrentFile();
                    dglMain.DataSource = MainTable.Copy();
                };
                this.Invoke(refresh);
            }));
            thread.Start();
        }

        private void RefreshOfferTable()
        {
            RefreshDelegate refresh = () =>
            {
                Global.PlaySound();
                dglOffer.DataSource = GetOfferTable();
                tabMain.SelectedTab = tagOffer;
                this.Activate();
            };
            this.Invoke(refresh);
        }

        private void SendOfferTable()
        {
            lock (DepartmentList)
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
        }

        private DataTable GetOfferTable()
        {
            var table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MO", typeof(string));
            table.Columns.Add("P/N", typeof(string));
            table.Columns.Add("Requset_Qtr", typeof(string));
            table.Columns.Add("Request_Time", typeof(string));
            table.Columns.Add("Remarks", typeof(string));
            lock (DepartmentList)
            {
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
                    newRow["MO"] = row["MO"];
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
                    newRow["Department"] = DepartmentList[1].Name;
                    newRow["Line"] = string.Empty;
                    newRow["Model"] = row["Model"];
                    newRow["IPN"] = row["IPN"];
                    newRow["MO"] = row["MO"];
                    newRow["P/N"] = row["P/N"];
                    newRow["Requset_Qtr"] = row["Requset_Qtr"];
                    newRow["Request_Time"] = row["Request_Time"];
                    newRow["Remarks"] = row["Remarks"];
                    table.Rows.Add(newRow);
                }
                return table;
            }
        }

        private void InitDepartment()
        {
            DepartmentList = new List<Department>();

            var table = new DataTable();
            table.Columns.Add("Department", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MO", typeof(string));
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
                MainTable.Columns.Add("MO", typeof(string));
                MainTable.Columns.Add("P/N", typeof(string));
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
            if (MessageBox.Show("Delete?", "Tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            else
            {
                MainPage.Focus();
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


        private void btnOffer_Click(object sender, EventArgs e)
        {
            Offer();
        }

        private void Offer()
        {
            if (dglOffer.CurrentCell != null)
            {
                if (dglOffer.CurrentCell.RowIndex >= 0)
                {
                    var index = dglOffer.CurrentCell.RowIndex;
                    if (dglOffer.CurrentCell.RowIndex < DepartmentList[0].OrderList.Rows.Count)
                    {
                        if (DepartmentList[0].OrderList.Rows.Count > 0)
                        {
                            if (DepartmentList[0].OrderList.Rows[index]["Remarks"].ToString() == Global.Wait)
                            {
                                DepartmentList[0].OrderList.Rows[index]["Remarks"] = Global.Sending;
                            }
                        }
                    }
                    else
                    {
                        if (DepartmentList[1].OrderList.Rows[index]["Remarks"].ToString() == Global.Wait)
                        {
                            index = index - DepartmentList[0].OrderList.Rows.Count;
                            DepartmentList[1].OrderList.Rows[index]["Remarks"] = Global.Sending;
                        }
                    }
                    RefreshOfferTable();
                    SendOfferTable();
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = lbTime2.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dglOffer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
                                else if (this.dglOffer.Rows[i].Cells[j].Value.ToString() == Global.Undo)
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
                    var width = (this.dglOffer.Width - dglOffer.RowHeadersWidth) / cell;
                    for (int i = 0; i < this.dglOffer.Columns.Count; i++)
                    {
                        this.dglOffer.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        this.dglOffer.Columns[i].Width = width;
                    }
                }
                dglOffer.Columns["Department"].HeaderText = "Department\r\n部门";
                dglOffer.Columns["Line"].HeaderText = "Line\r\n线别";
                dglOffer.Columns["Model"].HeaderText = "Model\r\n产品型号";
                dglOffer.Columns["IPN"].HeaderText = "IPN\r\n订单数";
                dglOffer.Columns["MO"].HeaderText = "MO\r\n工单号";
                dglOffer.Columns["P/N"].HeaderText = "P/N\r\n品号";
                dglOffer.Columns["Requset_Qtr"].HeaderText = "Requset Qtr\r\n需求数量";
                dglOffer.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
                dglOffer.Columns["Remarks"].HeaderText = "Remarks\r\n状态";
                dglOffer.Refresh();
            }
        }

        private void dglMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
                    var width = (this.dglMain.Width - dglMain.RowHeadersWidth) / cell;
                    for (int i = 0; i < this.dglMain.Columns.Count; i++)
                    {
                        this.dglMain.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        this.dglMain.Columns[i].Width = width;
                    }
                }
                dglMain.Columns["Machine"].HeaderText = "Machine\r\n设备";
                dglMain.Columns["Mould"].HeaderText = "Mould\r\n模具";
                dglMain.Columns["Material"].HeaderText = "Material\r\n物料";
                dglMain.Columns["IPN"].HeaderText = "IPN\r\n订单数";
                dglMain.Columns["MO"].HeaderText = "MO\r\n工单号";
                dglMain.Columns["P/N"].HeaderText = "P/N\r\n品号";
                dglMain.Columns["Order_Qty"].HeaderText = "Order Qty\r\n订单数量";
                dglMain.Columns["Start_Time"].HeaderText = "Start Time\r\n开始时间";
                dglMain.Columns["Daily_Plan"].HeaderText = "Daily Plan\r\n标准产能";
                dglMain.Columns["Actual_Output"].HeaderText = "Actual Output\r\n实际产能";
                dglMain.Columns["Man_Status"].HeaderText = "Man\r\n人员";
                dglMain.Columns["Machine_Status"].HeaderText = "Machine\r\n机器";
                dglMain.Columns["Material_Status"].HeaderText = "Material\r\n物料";
                dglMain.Columns["Method_Status"].HeaderText = "Method\r\n方法";
            }
        }

    }
}
