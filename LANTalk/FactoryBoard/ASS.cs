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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FactoryBoard
{
    public partial class ASS : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public static string CurrentOrder;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Server _server;

        public ASS(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }
        
        private void ASS_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Init();
        }

        private void StartServer()
        {
            try
            {
                _server = new LANTalk.Core.Server();

                var config = Global.LoadConfig();


                _server.StartServer(
                    IPAddress.Parse(config.Rows[0][Global.ASS_STRING].ToString()),
                    int.Parse(config.Rows[0][Global.PORT_STRING].ToString()),
                    SocketAcceptCallback,
                    SocketLostCallback,
                    ListenErrorCallback,
                    ReceiveCallback,
                    SendBefore,
                    null
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start Server Error：" + ex.Message, "Error");
                ReturnTitle();
            }
        }

        private string SendBefore(IPAddress ip)
        {
            Thread.Sleep(1000);
            return Mode.OnlineList.ToString() + " 0 0 " + GetOnlineList();
        }

        private string GetOnlineList()
        {
            var onlinelist = string.Empty;
            var departmentonline = DepartmentList.Where(o => o.Online == true);
            foreach (var department in departmentonline)
            {
                onlinelist += department.IP + ",";
            }
            onlinelist.TrimEnd(',');
            return onlinelist;
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

        private void SocketAcceptCallback(Socket socketor)
        {
            DepartmentOnline(socketor);
        }

        private void DepartmentOnline(Socket socketor)
        {
            lock (DepartmentList)
            {
                var temp = from row in DepartmentList
                           where row.IP == ((IPEndPoint)socketor.RemoteEndPoint).Address.ToString()
                           select row;
                if (temp.Count()>0)
                {
                    var department = temp.First();
                    department.Online = true;
                    department.Socketor = socketor;
                    switch (department.Name)
                    {
                        case Global.IJ:
                            btnIJ.Enabled = true;
                            RefreshOrderButton();
                            RefreshOrderList();
                            break;
                    }
                }
            }
        }

        private void SocketLostCallback(Socket socketor)
        {
            DepartmentOffline(socketor);
        }

        private void DepartmentOffline(Socket socketor)
        {
            lock (DepartmentList)
            {
                try
                {
                    var temp = from row in DepartmentList
                               where row.IP == ((IPEndPoint)socketor.RemoteEndPoint).Address.ToString()
                               select row;
                    if (temp.Count() > 0)
                    {
                        var department = temp.First();
                        department.Online = false;
                        department.Socketor = null;
                        switch (department.Name)
                        {
                            case Global.IJ:
                                btnIJ.Enabled = false;
                                if (CurrentOrder == Global.IJ)
                                {
                                    CurrentOrder = string.Empty;
                                }
                                RefreshOrderButton();
                                RefreshOrderList();
                                break;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void ListenErrorCallback(Exception ex)
        {
            if (!Return)
            {
                if (MessageBox.Show(this, "Detail：" + ex.Message, "Server Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    StartServer();
                }
                else
                {
                    ReturnTitle();
                }
            }
        }

        private void ReceiveCallback(IPAddress ip, string content)
        {
            try
            {
                lock (DepartmentList)
                {
                    var temp = from row in DepartmentList
                               where row.IP == ip.ToString()
                               select row;
                    if (temp.Count()>0)
                    {
                        var department = temp.First();
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
                                if (toip == ((IPEndPoint)department.Socketor.LocalEndPoint).Address.ToString())
                                {
                                    var offertable = CSVHelper.ReadTable(message);
                                    for (var i = 0; i < offertable.Rows.Count; i++)
                                    {
                                        department.OrderList.Rows[i]["Remarks"] = offertable.Rows[i]["Remarks"];
                                    }
                                    

                                    RefreshOrderList();
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }


        private void Init()
        {
            InitMainTable();
            InitDepartment();
            RefreshOrderList();
            RefreshOrderButton();
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\ASS";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
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

            DepartmentList.Add(new Department(config.Rows[0][Global.IJ_STRING].ToString(), Global.IJ, false,table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.WH_STRING].ToString(), Global.WH, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.eWH_STRING].ToString(), Global.eWH, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.SMT_STRING].ToString(), Global.SMT, false, table.Clone()));
            DepartmentList.Add(new Department(config.Rows[0][Global.SSP_STRING].ToString(), Global.SSP, false, table.Clone()));

        }

        private void InitMainTable()
        {
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
            MainPage.Focus();
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
            lock (dglMain)
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
                dglMain.Columns["Line"].HeaderText = "Line\r\n生产线";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Global.SaveFile(ASS.MainTable, Global.ASS_STRING);
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
            if (dglMain.CurrentCell != null)
            {
                var form = new ASSEdit(dglMain.CurrentCell.RowIndex);
                form.ShowDialog();
                dglMain.DataSource = MainTable.Copy();
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

        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadCurrentFile();
            dglMain.DataSource = MainTable.Copy();
        }


        private void LoadCurrentFile()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\ASS\\current.csv";
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
                MainTable.Columns.Add("Man_Status", typeof(string));
                MainTable.Columns.Add("Machine_Status", typeof(string));
                MainTable.Columns.Add("Material_Status", typeof(string));
                MainTable.Columns.Add("Method_Status", typeof(string));
            }
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
        }

        private void RefreshOrderButton()
        {
            btnIJ.BackColor = btnIJ.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
            btnWH.BackColor = btnWH.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
            btneWH.BackColor = btneWH.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
            btnSMT.BackColor = btnSMT.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
            btnSSP.BackColor = btnSSP.Enabled == true ? (btnIJ.Text == CurrentOrder ? Color.GreenYellow : Color.WhiteSmoke) : Color.Red;
        }

        private void btnIJ_Click(object sender, EventArgs e)
        {
            CurrentOrder = Global.IJ;
            RefreshOrderButton();
            RefreshOrderList();
        }
        
        private void btnWH_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ReturnTitle();
        }

        private void ReturnTitle()
        {
            Return = true;
            StopAllSocket();
            _server.StopServer();
            MainPage.Show();
            this.Close();
        }

        private void StopAllSocket()
        {
            lock (DepartmentList)
            {
                foreach (var department in DepartmentList)
                {
                    if (department.Socketor != null)
                    {
                        try
                        {
                            department.Socketor.Close();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            SendOrder();
        }

        private void SendOrder()
        {
            var department = GetCurrentDepartment();
            if (department != null)
            {
                var content = Mode.SendOrder.ToString();
                content += " " + _server._ip.ToString();
                content += " " + department.IP;
                content += " " + CSVHelper.MakeCSV(department.OrderList);
                _server.CustomSend(department.Socketor, content);
            }
        }

        private void dglOrder_DataSourceChanged(object sender, EventArgs e)
        {
            lock (dglOrder)
            {
                if (dglOrder.Rows.Count > 0)
                {
                    int row = dglOrder.Rows.Count;//得到总行数    
                    int cell = dglOrder.Rows[0].Cells.Count;//得到总列数    
                    for (int i = 0; i < row; i++)//得到总行数并在之内循环    
                    {
                        for (int j = 7; j < cell; j++)//得到总列数并在之内循环    
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
            }
        }


        private void RefreshOrderList()
        {
            lock (this)
            {
                var department = GetCurrentDepartment();
                if (department == null)
                {
                    dglOrder.Hide();
                    return;
                }


                dglOrder.DataSource = department.OrderList.Copy();
                dglOrder.Show();
            }
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
            lock (dglOrder)
            {
                if (dglOrder.CurrentCell.RowIndex > 0)
                {
                    if (department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"].ToString() != Global.Receive &&
                        department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"].ToString() != Global.UnKnown)
                    {
                        if (MessageBox.Show("确定撤销?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"] = Global.Revoke;
                        }
                        RefreshOrderList();
                    }
                }
            }
        }

        private void ASS_Shown(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var department = GetCurrentDepartment();
            if (department == null)
            {
                return;
            }
            lock (dglOrder)
            {
                if (dglOrder.CurrentCell.RowIndex > 0)
                {
                    if (department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"].ToString() == Global.Sending)
                    {
                        if (MessageBox.Show("确定接收?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            department.OrderList.Rows[dglOrder.CurrentCell.RowIndex]["Remarks"] = Global.Receive;
                        }
                        RefreshOrderList();
                    }
                }
            }
        }
    }
}
