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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql = "INSERT INTO tbl_calender (calender_title, calender_date, calender_content, user_id) VALUES (@title, @date, @content, @user_id)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("calender_date", textBoxDate.Text);
            cmd.Parameters.AddWithValue("calender_title", textBoxName.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            conn.Dispose();
            conn.Close();

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
