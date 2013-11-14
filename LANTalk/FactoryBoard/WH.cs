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

namespace FactoryBoard
{
    public partial class WH : Form
    {
        public static DataTable MainTable;
        public static List<Department> DepartmentList;
        public Main MainPage;
        private bool Return;
        private LANTalk.Core.Client _client;
        private delegate void RefreshDelegate();//定义委托

        public WH(Main mainpage)
        {
            MainPage = mainpage;
            Return = false;
            InitializeComponent();
        }

        private void WH_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Init();
        }

        private void Init()
        {
            InitDepartment();
            dglOffer.DataSource = GetOfferTable();
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\WH";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ofdOpenFile.InitialDirectory = path;
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
                    newRow["Department"] = DepartmentList[1].Name;
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

        private void WH_FormClosed(object sender, FormClosedEventArgs e)
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

        private void WH_Shown(object sender, EventArgs e)
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

        private void ConnectCallback()
        {
            RefreshDelegate refresh = () =>
            {
                btnConnect.Text = "Connected(已连接)";
                btnConnect.Enabled = false;
                btnOffer.Enabled = true;
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

        private void RefreshOfferTable()
        {
            RefreshDelegate refresh = () =>
            {
                Global.PlaySound();
                dglOffer.DataSource = GetOfferTable();
            };
            this.Invoke(refresh);
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
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

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ReturnTitle();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tTime_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            lbTime.Text = "Date:" + time.ToString("yyyy-MM-dd") + " Time:" + time.ToString("HH:mm:ss");
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
                dglOffer.Columns["Department"].HeaderText = "Department\r\n部门";
                dglOffer.Columns["Line"].HeaderText = "Line\r\n线别";
                dglOffer.Columns["Model"].HeaderText = "Model\r\n产品型号";
                dglOffer.Columns["IPN"].HeaderText = "IPN\r\n订单号码";
                dglOffer.Columns["MOA"].HeaderText = "MOA\r\n工单号";
                dglOffer.Columns["P/N"].HeaderText = "P/N\r\n品号";
                dglOffer.Columns["Requset_Qtr"].HeaderText = "Requset Qtr\r\n需求数量";
                dglOffer.Columns["Request_Time"].HeaderText = "Request Time\r\n需求时间";
                dglOffer.Columns["Remarks"].HeaderText = "Remarks\r\n状态";
                dglOffer.Refresh();
            }
        }
    }
}