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
    public partial class Daydetails : Form
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";

        public Daydetails()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            
            string queryDate = $"{Calender.static_year}-{Calender.static_month:D2}-{UserControlDays.static_day:D2}";
            MessageBox.Show("Loading events for date: " + queryDate);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT calender_title FROM tbl_calender WHERE DATE(calender_date) = @date";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", queryDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        listViewEvent.Items.Clear();
                        while (reader.Read())
                        {
                            string eventTitle = reader["calender_title"].ToString();
                            listViewEvent.Items.Add(eventTitle);
                            MessageBox.Show("Loaded event: " + eventTitle);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading events: {ex.Message}");
                }
            }
        }

        private void listViewEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewEvent.SelectedItems.Count > 0)
            {
                string selectedEventTitle = listViewEvent.SelectedItems[0].Text;
                var confirmResult = MessageBox.Show("Are you sure you want to delete this event?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    listViewEvent.Items.Remove(listViewEvent.SelectedItems[0]);
                    DeleteEventFromDatabase(selectedEventTitle);
                }
            }
            else
            {
                MessageBox.Show("Please select an event to delete.");
            }
        }

        private void DeleteEventFromDatabase(string eventTitle)
        {
            string queryDate = $"{Calender.static_year}-{Calender.static_month:D2}-{UserControlDays.static_day:D2}";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM tbl_calender WHERE calender_title = @title AND DATE(calender_date) = @date";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", eventTitle);
                    cmd.Parameters.AddWithValue("@date", queryDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Event deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error: Event could not be deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting event: {ex.Message}");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Implement update functionality if needed
        }
    }
}
