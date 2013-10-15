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
                        this.Hide();

                        break;
                }
            }
        }

        private void btnASS_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new ASS();
            form.Show();
        }
    }
}
