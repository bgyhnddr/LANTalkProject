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
using System.Net;
using DLLFullPrint;
using System.Threading.Tasks;
using System.Threading;
using FactoryBoard.Properties;

namespace FactoryBoard
{
    public partial class SSP : Form
    {
        public static DataTable MainTable;
        public static DataTable BlankTable;
        public static List<Department> DepartmentList;
        public static string CurrentOrder;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Client _client;

        private delegate void RefreshDelegate();//定义委托
        private delegate void RefreshDelegateString(string context);//定义委托
        private delegate void ShowMessageBox(Exception ex);//定义委托

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const int SC_DOUBLECLICK = 0xf122;//双击窗体标题栏  
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

        public SSP(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }


        private void SSP_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            Init();
            BindMouseMove();
        }

        private void Init()
        {
            InitMainTable();
            InitDepartment();
            dglOffer.DataSource = GetOfferTable();
            RefreshOrderList();
            RefreshOrderButton();
            var time = DateTime.Now;
            lbTime.Text = lbTime2.Text = lbTime3.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
            
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

        private void LoadCurrentFile()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\SSP\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
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

        private void InitDepartment()
        {
            DepartmentList = new List<Department>();

            var table = new DataTable();
            table.Columns.Add("Guid", typeof(string));
            table.Columns.Add("Send_Time", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MO", typeof(string));
            table.Columns.Add("Process", typeof(string));
            table.Columns.Add("P/N", typeof(string));
            table.Columns.Add("Requset_Qty", typeof(string));
            table.Columns.Add("Request_Time", typeof(string));
            table.Columns.Add("Status", typeof(string));
            BlankTable = table.Clone();
            BlankTable.Columns.Remove("Guid");
            var config = Global.LoadConfig();

            DepartmentList.Add(new Department(config.Rows[0][Global.ASS_STRING].ToString(), Global.ASS, false, table.Clone()));

            table.Columns.Remove("Line");
            DepartmentList.Add(new Department(config.Rows[0][Global.IJ_STRING].ToString(), Global.IJ, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.WH_STRING].ToString(), Global.WH, false, table.Clone()));
            InitOrderList();
        }

        private void RefreshOfferTable()
        {
            RefreshDelegate refresh = () =>
            {
                Global.PlaySound();
                tabMain.SelectedTab = tagOffer;
                dglOffer.DataSource = GetOfferTable();
                if (!this.TopMost)
                {
                    MainPage.TimerIcon.Start();
                }
            };
            this.Invoke(refresh);
        }

        private DataTable GetOfferTable()
        {
            var table = new DataTable();
            table.Columns.Add("Send_Time", typeof(string));
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MO", typeof(string));
            table.Columns.Add("Process", typeof(string));
            table.Columns.Add("P/N", typeof(string));
            table.Columns.Add("Requset_Qty", typeof(string));
            table.Columns.Add("Request_Time", typeof(string));
            table.Columns.Add("Status", typeof(string));
            lock (DepartmentList)
            {
                DataView DV = DepartmentList[0].OrderList.DefaultView;
                DV.Sort = "Status ASC";
                DepartmentList[0].OrderList = DV.ToTable();


                foreach (DataRow row in DepartmentList[0].OrderList.Rows)
                {
                    var newRow = table.NewRow();
                    newRow["Line"] = row["Line"];
                    newRow["Model"] = row["Model"];
                    newRow["IPN"] = row["IPN"];
                    newRow["MO"] = row["MO"];
                    newRow["Process"] = row["Process"];
                    newRow["P/N"] = row["P/N"];
                    newRow["Requset_Qty"] = row["Requset_Qty"];
                    newRow["Request_Time"] = row["Request_Time"];
                    newRow["Send_Time"] = row["Send_Time"];
                    newRow["Status"] = row["Status"];
                    table.Rows.Add(newRow);
                }
                return table;
            }
        }

        private void RefreshOrderList()
        {

            RefreshDelegate refresh = () =>
            {
                var department = GetCurrentDepartment();
                if (department == null)
                {
                    dglOrder.DataSource = BlankTable;
                    return;
                }

                DataView DV = department.OrderList.DefaultView;
                DV.Sort = "Status ASC";
                department.OrderList = DV.ToTable();
                var table = department.OrderList.Copy();
                table.Columns.Remove("Guid");
                dglOrder.DataSource = table;
            };

            this.Invoke(refresh);
        }

        public static Department GetCurrentDepartment()
        {
            var temp = from row in DepartmentList
                       where row.Name == CurrentOrder
                       select row;
            if (temp.Count() > 0)
            {
                var department = temp.First();
                return department;
            }
            return null;
        }

        private void RefreshOrderButton()
        {
            RefreshDelegate refresh = () =>
            {
                btnIJ.BackColor = btnIJ.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
                btnWH.BackColor = btnWH.Enabled == true ? (btnWH.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
            };
            this.Invoke(refresh);
        }


        private void dglMain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dglMain.CurrentCell != null)
            {
                var form = new SSPEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
            }
        }

        private void SSP_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveOrderList();
            if (!Return)
            {
                Application.Exit();
            }
            else
            {
                MainPage.Focus();
            }
        }

        private void SaveOrderList()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            foreach (var department in DepartmentList)
            {
                if (department.OrderList.Rows.Count > 0)
                {
                    var currentpath = path + "\\LANTalk\\OrderList";
                    currentpath += "\\" + department.Name;

                    if (!Directory.Exists(currentpath))
                    {
                        Directory.CreateDirectory(currentpath);
                    }

                    var now = DateTime.Now;

                    File.WriteAllText(currentpath + "\\" + now.ToString("yyyy-MM-dd") + ".csv", CSVHelper.MakeCSV(department.OrderList), Encoding.GetEncoding("GB2312"));

                    var DV = department.OrderList.DefaultView;
                    DV.RowFilter = string.Format("Status='{0}' OR Status='{1}'", Global.Wait, Global.Sending);
                    File.WriteAllText(currentpath + "\\" + now.AddDays(1).ToString("yyyy-MM-dd") + ".csv", CSVHelper.MakeCSV(DV.ToTable()), Encoding.GetEncoding("GB2312"));
                }
            }
        }

        private void InitOrderList()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            foreach (var department in DepartmentList)
            {
                var currentpath = path + "\\LANTalk\\OrderList";
                currentpath += "\\" + department.Name;
                currentpath += "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                if (File.Exists(currentpath))
                {
                    department.OrderList = CSVHelper.ReadCSVToTable(currentpath);
                }
            }
        }

        private void SSP_Shown(object sender, EventArgs e)
        {
            Connect();
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

        private void ReturnTitle()
        {
            Return = true;
            _client.DisConnect();
            MainPage.Show();
            this.Close();
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
                            switch (department.Name)
                            {
                                case Global.ASS:
                                    var receiveTable = CSVHelper.ReadTable(message);

                                    foreach (DataRow row in receiveTable.Rows)
                                    {
                                        var rows = department.OrderList.Select("Guid='" + row["Guid"].ToString() + "'");
                                        if (rows.Length > 0)
                                        {
                                            rows[0]["Status"] = row["Status"];
                                        }
                                        else
                                        {
                                            var newRow = department.OrderList.NewRow();
                                            foreach (DataColumn col in receiveTable.Columns)
                                            {
                                                newRow[col.ColumnName] = row[col.ColumnName];
                                            }
                                            department.OrderList.Rows.Add(newRow);
                                        }
                                    }

                                    SendOfferTable(-1, department.Name);
                                    RefreshOfferTable();
                                    break;
                                case Global.IJ:
                                case Global.WH:
                                    var offertable = CSVHelper.ReadTable(message);
                                    foreach (DataRow row in offertable.Rows)
                                    {
                                        var rows = department.OrderList.Select("Guid='" + row["Guid"].ToString() + "'");
                                        if (rows.Length > 0)
                                        {
                                            rows[0]["Status"] = row["Status"];
                                        }
                                    }
                                    RefreshOrderList();
                                    break;
                            }

                        }
                        break;
                    case Mode.OnlineList:
                        DepartmentOnOffLine(message);
                        break;
                }
            }
            catch
            {
            }
        }

        private void DepartmentOnOffLine(string ips)
        {
            RefreshDelegateString refresh = (x) =>
            {
                lock (DepartmentList)
                {
                    var change = false;
                    var temp = from row in DepartmentList
                               where x.IndexOf(row.IP) >= 0 && row.IP.Length > 0
                               select row;
                    foreach (var department in temp)
                    {
                        if (department.Online == false)
                        {
                            department.Online = true;
                            switch (department.Name)
                            {
                                case Global.IJ:
                                    btnIJ.Enabled = true;
                                    break;
                                case Global.WH:
                                    btnWH.Enabled = true;
                                    break;
                            }
                            change = true;
                            SendOrder(-2, department);
                        }
                    }

                    temp = from row in DepartmentList
                           where x.IndexOf(row.IP) < 0 || row.IP.Length == 0
                           select row;

                    foreach (var department in temp)
                    {
                        if (department.Online == true)
                        {
                            department.Online = false;
                            switch (department.Name)
                            {
                                case Global.IJ:
                                    btnIJ.Enabled = false;
                                    if (CurrentOrder == Global.IJ)
                                    {
                                        CurrentOrder = string.Empty;
                                    }
                                    break;
                                case Global.WH:
                                    btnWH.Enabled = false;
                                    if (CurrentOrder == Global.WH)
                                    {
                                        CurrentOrder = string.Empty;
                                    }
                                    break;
                            }
                            change = true;
                        }
                    }
                    if (change)
                    {
                        RefreshOrderButton();
                        RefreshOrderList();
                    }
                }
            };
            this.Invoke(refresh, ips);
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

        private void SendOfferTable(int index, string departmentname)
        {
            lock (DepartmentList)
            {
                foreach (var department in DepartmentList)
                {
                    if (department.Name == departmentname)
                    {
                        var sendTable = department.OrderList.Clone();
                        if (index == -1)
                        {
                            foreach (DataRow row in department.OrderList.Rows)
                            {
                                if (row["Status"].ToString() == Global.UnKnown)
                                {
                                    row["Status"] = Global.Wait;
                                    sendTable.Rows.Add(row.ItemArray);
                                }
                            }
                        }
                        else if (index >= 0)
                        {
                            sendTable.Rows.Add(department.OrderList.Rows[index].ItemArray);
                        }

                        var content = Mode.SendOrder.ToString();
                        content += " " + _client.ClientIP.ToString();
                        content += " " + department.IP;
                        content += " " + CSVHelper.MakeCSV(sendTable);
                        _client.SendContent(content);
                    }
                }
            }
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


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenFile.ShowDialog();
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\SSP";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
            if (!string.IsNullOrWhiteSpace(ofdOpenFile.FileName))
            {
                MainTable = CSVHelper.ReadCSVToTable(ofdOpenFile.FileName);
                dglMain.DataSource = MainTable.Copy();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet dy = new DataSet();
            dy.Tables.Add(SSP.MainTable.Copy());
            MyDLL.TakeOver(dy);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new SSPEdit(-1);
            form.ShowDialog();
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dglMain.CurrentCell != null)
            {
                var form = new SSPEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete?", "tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MainTable.Rows.RemoveAt(dglMain.CurrentCell.RowIndex);
                Global.SaveFile(SSP.MainTable, Global.SSP_STRING);
                MessageBox.Show("Saved");
            }
            dglMain.DataSource = MainTable.Copy();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ReturnTitle();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIJ_Click(object sender, EventArgs e)
        {
            CurrentOrder = Global.IJ;
            RefreshOrderButton();
            RefreshOrderList();
            dglOrder.Show();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var department = GetCurrentDepartment();
            if (department == null)
            {
                return;
            }
            var form = new SSPOrder(-1);
            form.ShowDialog();
            RefreshOrderList();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            var department = GetCurrentDepartment();
            if (department == null)
            {
                return;
            }
            if (dglOrder.CurrentCell.RowIndex >= 0)
            {
                if (department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Status"].ToString() != Global.Receive &&
                    department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Status"].ToString() != Global.UnKnown)
                {
                    if (MessageBox.Show("confirm?", "tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Status"] = Global.Undo;
                    }
                    SendOrder(dglOrder.CurrentCell.RowIndex);
                    RefreshOrderList();
                }
            }
        }

        private void SendOrder(int index = -1, Department dept = null)
        {
            Department department;
            if (dept == null)
            {
                department = GetCurrentDepartment();
            }
            else
            {
                department = dept;
            }
            if (department != null)
            {
                var sendTable = department.OrderList.Clone();


                if (index == -1)
                {
                    foreach (DataRow row in department.OrderList.Rows)
                    {
                        if (row["Status"].ToString() == Global.UnKnown)
                        {
                            row["Send_Time"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                            sendTable.Rows.Add(row.ItemArray);
                        }
                    }
                }
                else if (index == -2)
                {
                    sendTable = department.OrderList;
                }
                else if (index >= 0)
                {
                    sendTable.Rows.Add(department.OrderList.Rows[index].ItemArray);
                }

                var content = Mode.SendOrder.ToString();
                content += " " + _client.ClientIP.ToString();
                content += " " + department.IP;
                content += " " + CSVHelper.MakeCSV(sendTable);
                _client.SendContent(content);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SendOrder();
            }
            catch (Exception ex)
            {
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
                var index = dglOffer.CurrentCell.RowIndex;
                if (dglOffer.CurrentCell.RowIndex >= 0)
                {
                    if (DepartmentList[0].OrderList.Rows[index]["Status"].ToString() == Global.Wait)
                    {
                        DepartmentList[0].OrderList.Rows[index]["Status"] = Global.Sending;
                    }
                    SendOfferTable(dglOffer.CurrentCell.RowIndex, DepartmentList[0].Name);
                    RefreshOfferTable();
                }
            }
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = lbTime2.Text = lbTime3.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
            if (time - Global.LastMoveTime > new TimeSpan(0, Global.WAITTIME, 0))
            {
                if (tabMain.SelectedTab != tagMain)
                {
                    tabMain.SelectedTab = tagMain;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var department = GetCurrentDepartment();
            if (department == null)
            {
                return;
            }
            if (dglOrder.CurrentCell.RowIndex >= 0)
            {
                if (department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Status"].ToString() == Global.Sending)
                {
                    if (MessageBox.Show("confirm?", "tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Status"] = Global.Receive;
                    }
                    SendOrder(dglOrder.CurrentCell.RowIndex);
                    RefreshOrderList();
                }
            }
        }

        private void btnWH_Click(object sender, EventArgs e)
        {
            CurrentOrder = Global.WH;
            RefreshOrderButton();
            RefreshOrderList();
            dglOrder.Show();
        }

        private void SSP_Activated(object sender, EventArgs e)
        {
            MainPage.TimerIcon.Stop();
            MainPage.NotifyMain.Icon = Resources.LANTalkicon;
        }
        
        private void dglMain_DataSourceChanged(object sender, EventArgs e)
        {
            if (dglMain.Rows.Count > 0)
            {
                int row = dglMain.Rows.Count;//得到总行数    
                int cell = dglMain.Rows[0].Cells.Count;//得到总列数    
                for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                {
                    for (int j = cell - 4; j < cell; j++)
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
            }
            dglMain.Columns["Line"].FillWeight = 50;
            dglMain.Columns["Order_Qty"].FillWeight = 50;
            dglMain.Columns["Daily_Plan"].FillWeight = 50;
            dglMain.Columns["Actual_Output"].FillWeight = 50;
            dglMain.Columns["Man_Status"].FillWeight = 50;
            dglMain.Columns["Machine_Status"].FillWeight = 50;
            dglMain.Columns["Material_Status"].FillWeight = 50;
            dglMain.Columns["Method_Status"].FillWeight = 50;


            dglMain.Columns["Start_Time"].FillWeight = 180;


            dglMain.Columns["Line"].HeaderText = "Line\r\n线别";
            dglMain.Columns["Model"].HeaderText = "Model\r\n产品型号";
            dglMain.Columns["IPN"].HeaderText = "IPN\r\n订单号";
            dglMain.Columns["MO"].HeaderText = "MO\r\n工单号";
            dglMain.Columns["P/N"].HeaderText = "P/N\r\n品号";
            dglMain.Columns["Order_Qty"].HeaderText = "Order Qty\r\n订单数量";
            dglMain.Columns["Start_Time"].HeaderText = "Start Time\r\n开始时间";
            dglMain.Columns["Daily_Plan"].HeaderText = "Daily Plan\r\n每日计划";
            dglMain.Columns["Actual_Output"].HeaderText = "Actual Output\r\n实际产出";
            dglMain.Columns["Man_Status"].HeaderText = "Man\r\n人员";
            dglMain.Columns["Machine_Status"].HeaderText = "Machine\r\n机器";
            dglMain.Columns["Material_Status"].HeaderText = "Material\r\n物料";
            dglMain.Columns["Method_Status"].HeaderText = "Method\r\n方法";
        }

        private void dglOrder_DataSourceChanged(object sender, EventArgs e)
        {
            if (dglOrder.Rows.Count > 0)
            {
                int row = dglOrder.Rows.Count;//得到总行数    
                int cell = dglOrder.Rows[0].Cells.Count;//得到总列数    
                for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                {
                    if (dglOrder.Rows[i].Cells[cell - 1].Value != null)
                    {
                        if (this.dglOrder.Rows[i].Cells[cell - 1].Value.ToString() == Global.UnKnown)
                        {
                            this.dglOrder.Rows[i].Cells[cell - 1].Style.BackColor = Color.White;
                            this.dglOrder.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                        else if (this.dglOrder.Rows[i].Cells[cell - 1].Value.ToString() == Global.Undo)
                        {
                            this.dglOrder.Rows[i].Cells[cell - 1].Style.BackColor = Color.Gray;
                            this.dglOrder.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                        else if (this.dglOrder.Rows[i].Cells[cell - 1].Value.ToString() == Global.Wait)
                        {
                            this.dglOrder.Rows[i].Cells[cell - 1].Style.BackColor = Color.Red;
                            this.dglOrder.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                        else if (this.dglOrder.Rows[i].Cells[cell - 1].Value.ToString() == Global.Sending)
                        {
                            this.dglOrder.Rows[i].Cells[cell - 1].Style.BackColor = Color.Yellow;
                            this.dglOrder.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                        else if (this.dglOrder.Rows[i].Cells[cell - 1].Value.ToString() == Global.Receive)
                        {
                            this.dglOrder.Rows[i].Cells[cell - 1].Style.BackColor = Color.GreenYellow;
                            this.dglOrder.Rows[i].Cells[cell - 1].Value = string.Empty;
                        }
                    }
                }
            }
            dglOrder.Columns["Process"].FillWeight = 50;
            dglOrder.Columns["P/N"].FillWeight = 50;
            dglOrder.Columns["Requset_Qty"].FillWeight = 50;
            dglOrder.Columns["Status"].FillWeight = 50;

            dglOrder.Columns["Request_Time"].FillWeight = 180;
            dglOrder.Columns["Send_Time"].FillWeight = 180;

            dglOrder.Columns["Model"].HeaderText = "Model\r\n产品型号";
            dglOrder.Columns["IPN"].HeaderText = "IPN\r\n订单号";
            dglOrder.Columns["MO"].HeaderText = "MO\r\n工单号";
            dglOrder.Columns["Process"].HeaderText = "Process\r\n工艺";
            dglOrder.Columns["P/N"].HeaderText = "P/N\r\n品号";
            dglOrder.Columns["Requset_Qty"].HeaderText = "Requset Qty\r\n需求数量";
            dglOrder.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
            dglOrder.Columns["Send_Time"].HeaderText = "Send_Time\r\n发送时间";
            dglOrder.Columns["Status"].HeaderText = "Status\r\n状态";
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
                        if (dglOffer.Rows[i].Cells[cell - 1].Value != null)
                        {
                            if (this.dglOffer.Rows[i].Cells[cell - 1].Value.ToString() == Global.UnKnown)
                            {
                                this.dglOffer.Rows[i].Cells[cell - 1].Style.BackColor = Color.White;
                                this.dglOffer.Rows[i].Cells[cell - 1].Value = string.Empty;
                            }
                            else if (this.dglOffer.Rows[i].Cells[cell - 1].Value.ToString() == Global.Undo)
                            {
                                this.dglOffer.Rows[i].Cells[cell - 1].Style.BackColor = Color.Gray;
                                this.dglOffer.Rows[i].Cells[cell - 1].Value = string.Empty;
                            }
                            else if (this.dglOffer.Rows[i].Cells[cell - 1].Value.ToString() == Global.Wait)
                            {
                                this.dglOffer.Rows[i].Cells[cell - 1].Style.BackColor = Color.Red;
                                this.dglOffer.Rows[i].Cells[cell - 1].Value = string.Empty;
                            }
                            else if (this.dglOffer.Rows[i].Cells[cell - 1].Value.ToString() == Global.Sending)
                            {
                                this.dglOffer.Rows[i].Cells[cell - 1].Style.BackColor = Color.Yellow;
                                this.dglOffer.Rows[i].Cells[cell - 1].Value = string.Empty;
                            }
                            else if (this.dglOffer.Rows[i].Cells[cell - 1].Value.ToString() == Global.Receive)
                            {
                                this.dglOffer.Rows[i].Cells[cell - 1].Style.BackColor = Color.GreenYellow;
                                this.dglOffer.Rows[i].Cells[cell - 1].Value = string.Empty;
                            }
                        }
                    }
                }
                dglOffer.Columns["Process"].FillWeight = 50;
                dglOffer.Columns["P/N"].FillWeight = 50;
                dglOffer.Columns["Requset_Qty"].FillWeight = 50;
                dglOffer.Columns["Status"].FillWeight = 50;

                dglOffer.Columns["Request_Time"].FillWeight = 180;
                dglOffer.Columns["Send_Time"].FillWeight = 180;

                dglOffer.Columns["Model"].HeaderText = "Model\r\n产品型号";
                dglOffer.Columns["IPN"].HeaderText = "IPN\r\n订单号";
                dglOffer.Columns["MO"].HeaderText = "MO\r\n工单号";
                dglOffer.Columns["Process"].HeaderText = "Process\r\n工艺";
                dglOffer.Columns["P/N"].HeaderText = "P/N\r\n品号";
                dglOffer.Columns["Requset_Qty"].HeaderText = "Requset Qty\r\n需求数量";
                dglOffer.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
                dglOffer.Columns["Send_Time"].HeaderText = "Send_Time\r\n发送时间";
                dglOffer.Columns["Status"].HeaderText = "Status\r\n状态";
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            var department = GetCurrentDepartment();
            if (department == null)
            {
                return;
            }

            if (dglOrder.CurrentRow.Index >= 0)
            {
                var form = new SSPOrder(dglOrder.CurrentRow.Index);
                form.ShowDialog();
                RefreshOrderList();
            }
        }

        private void BindMouseMove()
        {
            foreach (System.Windows.Forms.Control control in this.tagOffer.Controls)//遍历Form上的所有控件  
            {
                control.MouseMove += new MouseEventHandler(this.MouseMoveAll);
            }

            foreach (System.Windows.Forms.Control control in this.tagOrder.Controls)//遍历Form上的所有控件  
            {
                control.MouseMove += new MouseEventHandler(this.MouseMoveAll);
            }

            foreach (System.Windows.Forms.Control control in this.Controls)//遍历Form上的所有控件  
            {
                control.MouseMove += new MouseEventHandler(this.MouseMoveAll);
            }
        }

        private void MouseMoveAll(object sender, EventArgs e)
        {
            Global.LastMoveTime = DateTime.Now;
        }
    }
}
