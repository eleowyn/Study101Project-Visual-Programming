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
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class addevent : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private int userId;

        public addevent()
        {
            InitializeComponent();
            userId = int.Parse(UserSession.user_id);
        }

        private void addevent_Load(object sender, EventArgs e)
        {
            string dateevent = $"{Calender.static_year}-{Calender.static_month:D2}-{UserControlDays.static_day:D2}";
            textBoxDate.Text = dateevent;
            textBoxDate.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Please enter an event title.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO tbl_calender (calender_title, calender_date, calender_content, user_id) VALUES (@title, @date, @content, @userId)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    cmd.Parameters.AddWithValue("@date", textBoxDate.Text);
                    cmd.Parameters.AddWithValue("@title", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@content", "Sample Content");
                    

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Event added successfully!");

                    var result = MessageBox.Show("Do you want to add another event?", "Event Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
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
