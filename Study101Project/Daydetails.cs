using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using static Study101Project.Form1; // Assuming UserSession is defined in Form1

namespace Study101Project
{
    public partial class Daydetails : Form
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";
        private int userId;

        public Daydetails()
        {
            InitializeComponent();
            userId = int.Parse(UserSession.user_id); // Get the logged-in user's ID
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
                    string query = "SELECT calender_title FROM tbl_calender WHERE DATE(calender_date) = @date AND user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", queryDate);
                    cmd.Parameters.AddWithValue("@userId", userId); // Filter by user_id

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
                    string query = "DELETE FROM tbl_calender WHERE calender_title = @title AND DATE(calender_date) = @date AND user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", eventTitle);
                    cmd.Parameters.AddWithValue("@date", queryDate);
                    cmd.Parameters.AddWithValue("@userId", userId); // Ensure only the user's events can be deleted

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
            // Add functionality for updating an event if required
        }

        private void Daydetails_Load(object sender, EventArgs e)
        {
            // Any additional initialization if needed
        }

        private void listViewEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Any additional initialization if needed
        }
    }
}
