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
            PopulateTypeComboBox();
        }

        private void PopulateTypeComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("All");
            comboBox1.Items.Add("Assignment");
            comboBox1.Items.Add("Exam");
            comboBox1.Items.Add("Project");
            comboBox1.Items.Add("Other");
            comboBox1.SelectedIndex = 0;
        }

        private void LoadTasks(string selectedType = "All")
        {
            checkedListBox1.DrawMode = DrawMode.Normal;
            checkedListBox1.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(alamat))
            {
                conn.Open();

                string query = selectedType == "All"
                    ? "SELECT task_title, task_duedate, task_type FROM tbl_task WHERE user_id = @userId"
                    : "SELECT task_title, task_duedate, task_type FROM tbl_task WHERE user_id = @userId AND task_type = @taskType";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    if (selectedType != "All")
                    {
                        cmd.Parameters.AddWithValue("@taskType", selectedType);
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string task = $"{reader["task_title"]} ({reader["task_type"]}) (Due: {Convert.ToDateTime(reader["task_duedate"]).ToShortDateString()})";
                            checkedListBox1.Items.Add(task, false);
                        }
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxName.Text) && comboBox1.SelectedIndex > 0)
            {
                string task = textBoxName.Text;
                string taskType = comboBox1.SelectedItem.ToString();
                string dueDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                using (MySqlConnection conn = new MySqlConnection(alamat))
                {
                    conn.Open();
                    string query = "INSERT INTO tbl_task (task_title, task_type, task_duedate, user_id) VALUES (@task, @taskType, @dueDate, @userId)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@task", task);
                        cmd.Parameters.AddWithValue("@taskType", taskType);
                        cmd.Parameters.AddWithValue("@dueDate", dueDate);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    textBoxName.Clear();

                    comboBox1.SelectedIndex = 0;

                    LoadTasks();
                }
            }
            else
            {
                MessageBox.Show("Please enter a task name and select a type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null && checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex))
            {
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                string taskName = selectedTask.Split(new string[] { " (" }, StringSplitOptions.None)[0];

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

                LoadTasks(comboBox1.SelectedItem.ToString());
                MessageBox.Show("Task deleted automatically after being checked from both To-Do list and Calendar.", "Task Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                string selectedTask = checkedListBox1.SelectedItem.ToString();
                string taskName = selectedTask.Split(new string[] { " (" }, StringSplitOptions.None)[0];

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

                LoadTasks(comboBox1.SelectedItem.ToString());
                MessageBox.Show("Task deleted successfully from To-Do Lists", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a task to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxName.Text.ToLower();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                try
                {
                    checkedListBox1.DrawMode = DrawMode.OwnerDrawFixed;
                    checkedListBox1.Items.Clear();

                    using (MySqlConnection conn = new MySqlConnection(alamat))
                    {
                        conn.Open();
                        query = "SELECT task_title, task_duedate FROM tbl_task WHERE user_id = @userId";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string taskTitle = reader["task_title"].ToString();
                                    DateTime dueDate = Convert.ToDateTime(reader["task_duedate"]);
                                    string dueDateStr = dueDate.ToShortDateString();
                                    string displayText = $"{taskTitle} (Due: {dueDateStr})";

                                    bool isMatch = taskTitle.ToLower().Contains(searchQuery) ||
                                                 dueDateStr.ToLower().Contains(searchQuery);

                                    checkedListBox1.Items.Add(new SearchItem
                                    {
                                        Text = displayText,
                                        IsHighlighted = isMatch
                                    });
                                }
                            }
                        }
                    }

                    checkedListBox1.DrawItem -= CheckedListBox1_DrawItem;
                    checkedListBox1.DrawItem += CheckedListBox1_DrawItem;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while searching: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadTasks();
            }
        }

        private class SearchItem
        {
            public string Text { get; set; }
            public bool IsHighlighted { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void CheckedListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            SearchItem item = checkedListBox1.Items[e.Index] as SearchItem;

            if (item != null)
            {
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.X + 1, e.Bounds.Y + 1),
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);

                Rectangle textBounds = new Rectangle(
                    e.Bounds.X + 20,
                    e.Bounds.Y,
                    e.Bounds.Width - 20,
                    e.Bounds.Height);

                if (item.IsHighlighted)
                {
                    using (SolidBrush highlightBrush = new SolidBrush(Color.Yellow))
                    {
                        e.Graphics.FillRectangle(highlightBrush, textBounds);
                    }
                }

                TextRenderer.DrawText(e.Graphics, item.Text, e.Font,
                    textBounds, Color.Black, TextFormatFlags.VerticalCenter);
            }

            e.DrawFocusRectangle();
        }

        private void labelType_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox1.SelectedItem.ToString();
            LoadTasks(selectedType);
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
