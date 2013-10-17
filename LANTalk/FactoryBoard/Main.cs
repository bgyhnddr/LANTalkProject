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

        public const string DEPARTMENT_STRING = "department";
        public const string ASS_STRING = "ASS";
        public const string WH_STRING = "WH";
        public const string eWH_STRING = "eWH";
        public const string IJ_STRING = "IJ";
        public const string SMT_STRING = "SMT";
        public const string SSP_STRING = "SSP";


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
            table.Columns.Add(DEPARTMENT_STRING, typeof(string));
            table.Columns.Add(ASS_STRING, typeof(string));
            table.Columns.Add(WH_STRING, typeof(string));
            table.Columns.Add(eWH_STRING, typeof(string));
            table.Columns.Add(IJ_STRING, typeof(string));
            table.Columns.Add(SMT_STRING, typeof(string));
            table.Columns.Add(SSP_STRING, typeof(string));

            var row = table.NewRow();
            row[DEPARTMENT_STRING] = department;
            row[ASS_STRING] = tbASSIP.Text;
            row[WH_STRING] = tbWHIP.Text;
            row[eWH_STRING] = tbeWHIP.Text;
            row[IJ_STRING] = tbIJIP.Text;
            row[SMT_STRING] = tbSMTIP.Text;
            row[SSP_STRING] = tbSSPIP.Text;

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
                switch (config.Rows[0][DEPARTMENT_STRING].ToString())
                {
                    case Global.ASS:
                        var form = new ASS(this);
                        form.Show();
                        break;
                }
            }
        }
    }
}
