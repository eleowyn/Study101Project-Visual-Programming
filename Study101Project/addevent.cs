using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study101Project
{
    public partial class addevent : Form
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";
        public addevent()
        {
            InitializeComponent();
        }

        private void addevent_Load(object sender, EventArgs e)
        {

        }
    }
}
