using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class TodoList : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;
        private int userId;

        public TodoList()
        {
            alamat = "server=localhost; database=db_study101; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            userId = int.Parse(UserSession.user_id);
            LoadTasks();
        }

        private void LoadTasks()
        {
            checkedListBox1.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(alamat))
            {
                conn.Open();

                string query = "SELECT task_title, task_duedate FROM tbl_task WHERE user_id = @userId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string task = $"{reader["task_title"]} (Due: {Convert.ToDateTime(reader["task_duedate"]).ToShortDateString()})";
                            checkedListBox1.Items.Add(task, false);
                        }
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text))
            {
                string task = textBoxName.Text;
                string dueDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                using (MySqlConnection conn = new MySqlConnection(alamat))
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_task (task_title, task_duedate, user_id) VALUES (@task, @dueDate, @userId)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@task", task);
                        cmd.Parameters.AddWithValue("@dueDate", dueDate);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadTasks();
                }
            }
            else
            {
                MessageBox.Show("Please enter a task name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null && checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex))
            {
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                string taskName = selectedTask.Split(new string[] { " (Due: " }, StringSplitOptions.None)[0];

                using (MySqlConnection conn = new MySqlConnection(alamat))
                {
                    conn.Open();
                    string query = "DELETE FROM tbl_task WHERE task_title = @taskName AND user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@taskName", taskName);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadTasks();

                MessageBox.Show("Task deleted automatically after being checked from both To-Do list and Calendar.", "Task Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                string taskName = selectedTask.Split(new string[] { " (Due: " }, StringSplitOptions.None)[0];

                using (MySqlConnection conn = new MySqlConnection(alamat))
                {
                    conn.Open();
                    string query = "DELETE FROM tbl_task WHERE task_title = @taskName AND user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@taskName", taskName);
                        cmd.Parameters.AddWithValue("@userId", userId); // Delete only if task belongs to current user
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadTasks();

                MessageBox.Show("Task deleted successfully from both To-Do list and Calendar.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxName.Text;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                checkedListBox1.Items.Clear();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(alamat))
                    {
                        conn.Open();

                        query = "SELECT task_title, task_duedate FROM tbl_task WHERE task_title LIKE @searchQuery AND user_id = @userId";
                        perintah = new MySqlCommand(query, conn);
                        perintah.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                        perintah.Parameters.AddWithValue("@userId", userId);

                        adapter = new MySqlDataAdapter(perintah);
                        ds = new DataSet();
                        adapter.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            string task = $"{row["task_title"]} (Due: {Convert.ToDateTime(row["task_duedate"]).ToShortDateString()})";
                            checkedListBox1.Items.Add(task, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void labelType_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void TodoList_Load(object sender, EventArgs e)
        {

        }

        private void labelDataTodo_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelTodo_Click(object sender, EventArgs e)
        {

        }
    }
}
