using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study101Project
{
    public partial class UserControlDays : UserControl
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        public void days(int numday)
        {
            label1Bdays.Text = numday.ToString();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = label1Bdays.Text;
            Choose chooseForm = new Choose();
            chooseForm.ShowDialog();
        }


        private void LoadEvents()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM tbl_calender where calender_date = @date";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            string date = UserControlDays.static_day + "/" + Calender.static_month + "/" + Calender.static_year;
            cmd.Parameters.AddWithValue("@date", date);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }
    }
}
