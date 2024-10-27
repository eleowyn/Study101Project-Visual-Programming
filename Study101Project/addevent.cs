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
        string dateevent;

        public addevent()
        {
            InitializeComponent();
        }

        private void addevent_Load(object sender, EventArgs e)
        {
            
            dateevent = $"{Calender.static_year}-{Calender.static_month:D2}-{UserControlDays.static_day:D2}";
            textBoxDate.Text = dateevent;
            textBoxDate.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO tbl_calender (calender_title, calender_date, calender_content, user_id) VALUES (@title, @date, @content, @user_id)";
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;

                   
                    cmd.Parameters.AddWithValue("@date", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@title", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@content", "Sample Content");
                    cmd.Parameters.AddWithValue("@user_id", 1);

                    cmd.ExecuteNonQuery();

                    var result = MessageBox.Show("Event added successfully! Do you want to add another event?", "Event Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        
                        textBoxName.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxDate_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
