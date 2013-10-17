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

        private void btnASS_Click(object sender, EventArgs e)
        {
            SaveConfig(Global.ASS);
            var form = new ASS(this);
            form.Show();
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

            var row = table.NewRow();
            row[Global.DEPARTMENT_STRING] = department;
            row[Global.ASS_STRING] = tbASSIP.Text;
            row[Global.WH_STRING] = tbWHIP.Text;
            row[Global.eWH_STRING] = tbeWHIP.Text;
            row[Global.IJ_STRING] = tbIJIP.Text;
            row[Global.SMT_STRING] = tbSMTIP.Text;
            row[Global.SSP_STRING] = tbSSPIP.Text;

            table.Rows.Add(row);

            Global.SaveConfig(table);
        }

        private void Main_Shown(object sender, EventArgs e)
        {

            if (!Global.ConfigExists())
            {
                return;
            }
            DataTable config = Global.LoadConfig();
            if (config != null)
            {
                tbASSIP.Text = config.Rows[0][Global.ASS_STRING].ToString();
                tbWHIP.Text = config.Rows[0][Global.WH_STRING].ToString();
                tbeWHIP.Text = config.Rows[0][Global.eWH_STRING].ToString();
                tbIJIP.Text = config.Rows[0][Global.IJ_STRING].ToString();
                tbSMTIP.Text = config.Rows[0][Global.SMT_STRING].ToString();
                tbSSPIP.Text = config.Rows[0][Global.SSP_STRING].ToString();


                switch (config.Rows[0][Global.DEPARTMENT_STRING].ToString())
                {
                    case Global.ASS:
                        var form = new ASS(this);
                        form.Show();
                        this.Hide();
                        break;
                }
            }
        }
    }
}
