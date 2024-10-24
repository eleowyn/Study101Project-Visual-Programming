using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study101Project
{
    public partial class CalendarTracker : Form
    {
        string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";

        public CalendarTracker()
        {
            InitializeComponent();
            tableLayoutPanel1_Paint(null, null);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string taskName = textBoxName.Text;
            string taskType = comboBoxType.SelectedItem?.ToString() ?? "General";

            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Please enter a task name.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_task (task_title, task_duedate, task_type, user_id) VALUES (@title, @duedate, @type, @user_id)", conn);
                cmd.Parameters.AddWithValue("@title", taskName);
                cmd.Parameters.AddWithValue("@duedate", selectedDate);
                cmd.Parameters.AddWithValue("@type", taskType);
                cmd.Parameters.AddWithValue("@user_id", 1);

                cmd.ExecuteNonQuery();
            }

            
            tableLayoutPanel1_Paint(null, null);
            textBoxName.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string taskName = textBoxName.Text;

            if (string.IsNullOrEmpty(taskName))
            {
                MessageBox.Show("Please enter the task name to delete.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_task WHERE task_title = @title AND task_duedate = @duedate", conn);
                cmd.Parameters.AddWithValue("@title", taskName);
                cmd.Parameters.AddWithValue("@duedate", selectedDate);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Task deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Task not found.");
                }
            }

            
            tableLayoutPanel1_Paint(null, null);
            textBoxName.Clear();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            int startDayOffset = (int)startDate.DayOfWeek;

            for (int i = 0; i < startDayOffset; i++)
            {
                tableLayoutPanel1.Controls.Add(new Label());
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                
                MySqlCommand cmd = new MySqlCommand("SELECT task_duedate, COUNT(*) as task_count FROM tbl_task WHERE MONTH(task_duedate) = @month AND YEAR(task_duedate) = @year GROUP BY task_duedate", conn);
                cmd.Parameters.AddWithValue("@month", DateTime.Now.Month);
                cmd.Parameters.AddWithValue("@year", DateTime.Now.Year);

                MySqlDataReader reader = cmd.ExecuteReader();

                var taskDates = new Dictionary<DateTime, int>();

                while (reader.Read())
                {
                    DateTime taskDate = Convert.ToDateTime(reader["task_duedate"]);
                    int taskCount = Convert.ToInt32(reader["task_count"]);
                    taskDates[taskDate] = taskCount;
                }

                reader.Close();

                
                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                    Button dayButton = new Button();
                    dayButton.Text = day.ToString();

                    
                    if (taskDates.ContainsKey(currentDate))
                    {
                        dayButton.BackColor = Color.LightGreen;
                        dayButton.Text += $" ({taskDates[currentDate]})";
                    }
                    else
                    {
                        dayButton.BackColor = Color.White;
                    }

                    dayButton.Tag = currentDate;
                    dayButton.Dock = DockStyle.Fill;
                    dayButton.Click += DayButton_Click;
                    tableLayoutPanel1.Controls.Add(dayButton);
                }
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = (DateTime)((Button)sender).Tag;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT task_title, task_type FROM tbl_task WHERE task_duedate = @date", conn);
                cmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        string tasks = $"Tasks for {selectedDate.ToString("yyyy-MM-dd")}:\n";
                        while (reader.Read())
                        {
                            tasks += $"{reader["task_title"]} ({reader["task_type"]})\n";
                        }
                        MessageBox.Show(tasks);
                    }
                    else
                    {
                        MessageBox.Show("No tasks for this day.");
                    }
                }
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBoxType.SelectedItem?.ToString();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_task WHERE task_type = @type", conn);
                cmd.Parameters.AddWithValue("@type", selectedType);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MessageBox.Show($"Task: {reader["task_title"]} | Date: {reader["task_duedate"]}");
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();

            this.Close();
        }
    }
}
