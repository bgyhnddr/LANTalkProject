using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FactoryBoard
{
    public partial class Main : Form
    {
        public static List<Department> _department;
        private static DataTable Config;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            _department = new List<Department>();
        }

        private void SaveConfig(string department)
        {
            var table = new DataTable();
            table.Columns.Add(Global.DEPARTMENT_STRING, typeof(string));
            table.Columns.Add(Global.ASS_STRING, typeof(string));
            table.Columns.Add(Global.WH_STRING, typeof(string));
            table.Columns.Add(Global.eWH_STRING, typeof(string));
            table.Columns.Add(Global.IJ_STRING, typeof(string));
            table.Columns.Add(Global.SMT_STRING, typeof(string));
            table.Columns.Add(Global.SSP_STRING, typeof(string));
            table.Columns.Add(Global.PORT_STRING, typeof(string));

            var row = table.NewRow();
            row[Global.DEPARTMENT_STRING] = department;
            row[Global.ASS_STRING] = tbASSIP.Text;
            row[Global.WH_STRING] = tbWHIP.Text;
            row[Global.eWH_STRING] = tbeWHIP.Text;
            row[Global.IJ_STRING] = tbIJIP.Text;
            row[Global.SMT_STRING] = tbSMTIP.Text;
            row[Global.SSP_STRING] = tbSSPIP.Text;
            row[Global.PORT_STRING] = tbPort.Text;

            table.Rows.Add(row);

            Global.SaveConfig(table);
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Global.ErrorMessage))
            {
                MessageBox.Show(Global.ErrorMessage);
                return;
            }

            if (!Global.ConfigExists())
            {
                return;
            }
            Config = Global.LoadConfig();
            if (Config != null)
            {
                try
                {
                    tbASSIP.Text = Config.Rows[0][Global.ASS_STRING].ToString();
                    tbWHIP.Text = Config.Rows[0][Global.WH_STRING].ToString();
                    tbeWHIP.Text = Config.Rows[0][Global.eWH_STRING].ToString();
                    tbIJIP.Text = Config.Rows[0][Global.IJ_STRING].ToString();
                    tbSMTIP.Text = Config.Rows[0][Global.SMT_STRING].ToString();
                    tbSSPIP.Text = Config.Rows[0][Global.SSP_STRING].ToString();
                    tbPort.Text = Config.Rows[0][Global.PORT_STRING].ToString();


                    switch (Config.Rows[0][Global.DEPARTMENT_STRING].ToString())
                    {
                        case Global.ASS:
                            new ASS(this).Show();
                            this.Hide();
                            break;
                        case Global.IJ:
                            new IJ(this).Show();
                            this.Hide();
                            break;
                        case Global.SSP:
                            new SSP(this).Show();
                            this.Hide();
                            break;
                        case Global.SMT:
                            new SMT(this).Show();
                            this.Hide();
                            break;
                        case Global.WH:
                            new WH(this).Show();
                            this.Hide();
                            break;
                        case Global.eWH:
                            new eWH(this).Show();
                            this.Hide();
                            break;
                    }
                }
                catch
                {
                }
            }
        }

        private void btnIJ_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.IJ);
            new IJ(this).Show();
        }

        private void btnSSP_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.SSP);
            new SSP(this).Show();
        }

        private void btnASS_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.ASS);
            new ASS(this).Show(); 
        }

        private void btnSMT_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.SMT);
            new SMT(this).Show(); 
        }

        private void btnWH_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.WH);
            new WH(this).Show(); 
        }

        private void btneWH_Click(object sender, EventArgs e)
        {
            this.Hide();
            SaveConfig(Global.eWH);
            new eWH(this).Show(); 

        }

        private void NotifyMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Application.OpenForms.Count > 1)
            {
                Application.OpenForms[1].WindowState = FormWindowState.Maximized;
                NotifyMain.Visible = false;
            }
        }
    }
}
