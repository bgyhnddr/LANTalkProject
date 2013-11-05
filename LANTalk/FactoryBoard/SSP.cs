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
using System.Net;
using DLLFullPrint;
using System.Threading.Tasks;
using System.Threading;

namespace FactoryBoard
{
    public partial class SSP : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public static string CurrentOrder;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Client _client;

        private delegate void RefreshDelegate();//定义委托
        private delegate void RefreshDelegateString(string context);//定义委托
        private delegate void ShowMessageBox(Exception ex);//定义委托

        public SSP(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }


        private void SSP_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Init();
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
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\SSP";
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
            path += "\\LANTalk\\SaveFile\\SSP\\current.csv";
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

            table.Columns.Remove("Line");
            DepartmentList.Add(new Department(config.Rows[0][Global.IJ_STRING].ToString(), Global.IJ, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.WH_STRING].ToString(), Global.WH, false, table.Clone()));


        }

        private void RefreshOfferTable()
        {
            RefreshDelegate refresh = () =>
            {
                Global.PlaySound();
                tabMain.SelectedTab = tagOffer;
                dglOffer.DataSource = GetOfferTable();
            };
            this.Invoke(refresh);
        }

        private DataTable GetOfferTable()
        {
            var table = new DataTable();
            table.Columns.Add("Line", typeof(string));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("IPN", typeof(string));
            table.Columns.Add("MOA", typeof(string));
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
                    dglOrder.Hide();
                    return;
                }
                dglOrder.DataSource = department.OrderList.Copy();
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
                    currentpath += "\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".csv";
                    File.WriteAllText(currentpath, CSVHelper.MakeCSV(department.OrderList), Encoding.GetEncoding("GB2312"));
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
                MessageBox.Show("连接服务失败：" + ex.Message, "错误");
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
                btnConnect.Enabled = false;
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
                            department.OrderList = CSVHelper.ReadTable(message);
                            switch (department.Name)
                            {
                                case Global.ASS:
                                    Global.PlaySound();
                                    RefreshOfferTable();
                                    SendOfferTable();
                                    break;
                                case Global.IJ:
                                case Global.WH:
                                    var offertable = CSVHelper.ReadTable(message);
                                    for (var i = 0; i < offertable.Rows.Count; i++)
                                    {
                                        department.OrderList.Rows[i]["Remarks"] = offertable.Rows[i]["Remarks"];
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
                        }
                    }

                    RefreshOrderButton();
                    RefreshOrderList();
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

        private void SendOfferTable()
        {
            lock (DepartmentList)
            {
                var department = DepartmentList[0];
                var content = Mode.SendOrder.ToString();
                content += " " + _client.ClientIP.ToString();
                content += " " + department.IP;
                content += " " + CSVHelper.MakeCSV(department.OrderList);
                _client.SendContent(content);
            }
        }

        private void ErrorCallback(Exception ex)
        {
            RefreshDelegate refresh = () =>
            {
                btnConnect.Text = "Connect(连接)";
                btnConnect.Enabled = true;
                btnOffer.Enabled = false;

            };
            if (!Return)
            {
                this.Invoke(refresh);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SaveFile(SSP.MainTable, Global.SSP_STRING);
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
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
            var form = new ASSOrder();
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
                if (department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"].ToString() != Global.Receive &&
                    department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"].ToString() != Global.UnKnown)
                {
                    if (MessageBox.Show("confirm?", "tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"] = Global.Revoke;
                    }
                    RefreshOrderList();
                    SendOrder();
                }
            }
        }

        private void SendOrder()
        {
            var department = GetCurrentDepartment();
            if (department != null)
            {
                var content = Mode.SendOrder.ToString();
                content += " " + _client.ClientIP.ToString();
                content += " " + department.IP;
                content += " " + CSVHelper.MakeCSV(department.OrderList);
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
                    if (index < DepartmentList[0].OrderList.Rows.Count)
                    {
                        if (DepartmentList[0].OrderList.Rows[index]["Remarks"].ToString() == Global.Wait)
                        {
                            DepartmentList[0].OrderList.Rows[index]["Remarks"] = Global.Sending;
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

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = lbTime2.Text = lbTime3.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void dglMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
            dglMain.Columns["Line"].HeaderText = "Line\r\n线别";
            dglMain.Columns["Model"].HeaderText = "Model\r\n产品型号";
            dglMain.Columns["IPN"].HeaderText = "IPN\r\n订单号码";
            dglMain.Columns["MOA"].HeaderText = "MOA\r\n工单号";
            dglMain.Columns["P/N"].HeaderText = "P/N\r\n品号";
            dglMain.Columns["Order_Qty"].HeaderText = "Order Qty\r\n订单数量";
            dglMain.Columns["Start_Time"].HeaderText = "Start Time\r\n开始时间";
            dglMain.Columns["Daily_Plan"].HeaderText = "Daily Plan\r\n标准产能";
            dglMain.Columns["Actual_Output"].HeaderText = "Actual Output\r\n实际产能";
            dglMain.Columns["Man_Status"].HeaderText = "Man\r\n人数";
            dglMain.Columns["Machine_Status"].HeaderText = "Machine\r\n机器";
            dglMain.Columns["Material_Status"].HeaderText = "Material\r\n物料";
            dglMain.Columns["Method_Status"].HeaderText = "Method\r\n方法";
        }

        private void dglOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dglOrder.Rows.Count > 0)
            {
                int row = dglOrder.Rows.Count;//得到总行数    
                int cell = dglOrder.Rows[0].Cells.Count;//得到总列数    
                for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                {
                    for (int j = 6; j < cell; j++)//得到总列数并在之内循环    
                    {
                        if (dglOrder.Rows[i].Cells[j].Value != null)
                        {
                            if (this.dglOrder.Rows[i].Cells[j].Value.ToString() == Global.UnKnown)
                            {
                                this.dglOrder.Rows[i].Cells[j].Style.BackColor = Color.White;
                                this.dglOrder.Rows[i].Cells[j].Value = string.Empty;
                            }
                            else if (this.dglOrder.Rows[i].Cells[j].Value.ToString() == Global.Revoke)
                            {
                                this.dglOrder.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                                this.dglOrder.Rows[i].Cells[j].Value = string.Empty;
                            }
                            else if (this.dglOrder.Rows[i].Cells[j].Value.ToString() == Global.Wait)
                            {
                                this.dglOrder.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                this.dglOrder.Rows[i].Cells[j].Value = string.Empty;
                            }
                            else if (this.dglOrder.Rows[i].Cells[j].Value.ToString() == Global.Sending)
                            {
                                this.dglOrder.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                                this.dglOrder.Rows[i].Cells[j].Value = string.Empty;
                            }
                            else if (this.dglOrder.Rows[i].Cells[j].Value.ToString() == Global.Receive)
                            {
                                this.dglOrder.Rows[i].Cells[j].Style.BackColor = Color.GreenYellow;
                                this.dglOrder.Rows[i].Cells[j].Value = string.Empty;
                            }
                        }
                    }
                }
                for (int i = 0; i < this.dglOrder.Columns.Count; i++)
                {
                    this.dglOrder.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            dglOrder.Columns["Model"].HeaderText = "Model\r\n产品型号";
            dglOrder.Columns["IPN"].HeaderText = "IPN\r\n订单号码";
            dglOrder.Columns["MOA"].HeaderText = "MOA\r\n工单号";
            dglOrder.Columns["P/N"].HeaderText = "P/N\r\n品号";
            dglOrder.Columns["Requset_Qtr"].HeaderText = "Requset Qtr\r\n需求数量";
            dglOrder.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
            dglOrder.Columns["Remarks"].HeaderText = "Remarks\r\n状态";
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
                        for (int j = 7; j < cell; j++)//得到总列数并在之内循环    
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

                dglOffer.Columns["Model"].HeaderText = "Model\r\n产品型号";
                dglOffer.Columns["IPN"].HeaderText = "IPN\r\n订单号码";
                dglOffer.Columns["MOA"].HeaderText = "MOA\r\n工单号";
                dglOffer.Columns["P/N"].HeaderText = "P/N\r\n品号";
                dglOffer.Columns["Requset_Qtr"].HeaderText = "Requset Qtr\r\n需求数量";
                dglOffer.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
                dglOffer.Columns["Remarks"].HeaderText = "Remarks\r\n状态";
            }
        }
    }
}
