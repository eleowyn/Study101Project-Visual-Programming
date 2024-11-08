using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class Daydetails : Form
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";
        private int userId;

        public Daydetails()
        {
            InitializeComponent();
            ConfigureListView();
            userId = int.Parse(UserSession.user_id);
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
                    cmd.Parameters.AddWithValue("@userId", userId);

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
                    cmd.Parameters.AddWithValue("@userId", userId);

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
            Choose choose = new Choose();
            choose.Show();
            this.Close();
        }

        private void Daydetails_Load(object sender, EventArgs e)
        {
            
        }

        private void listViewEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ConfigureListView()
        {
            listViewEvent.View = View.Details;
            listViewEvent.FullRowSelect = true;
            listViewEvent.BorderStyle = BorderStyle.Fixed3D;
            listViewEvent.GridLines = true;
            listViewEvent.Font = new Font("Century Gothic", 16, FontStyle.Regular);
            listViewEvent.ForeColor = Color.DarkSlateGray;
            listViewEvent.BackColor = Color.MistyRose;
            listViewEvent.HeaderStyle = ColumnHeaderStyle.None;

            listViewEvent.Columns.Add("Event Title", -2, HorizontalAlignment.Left);

            listViewEvent.OwnerDraw = true;
            listViewEvent.DrawItem += ListViewEvent_DrawItem;
        }

        private void ListViewEvent_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.ItemIndex % 2 == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 248, 255)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
            }

            e.Graphics.DrawString(e.Item.Text, listViewEvent.Font, Brushes.DarkSlateGray, e.Bounds);

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightSteelBlue), e.Bounds);
                e.Graphics.DrawString(e.Item.Text, listViewEvent.Font, Brushes.Black, e.Bounds);
            }

            e.DrawFocusRectangle();
        }
    }
}
