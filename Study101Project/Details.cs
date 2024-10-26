using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study101Project
{
    public partial class Details : Form
    {
        
        private string connectionString = "Server=127.0.0.1;Database=db_study101;Uid=root;Pwd=;";

        public Details()
        {
            InitializeComponent();
        }

        
        private void Details_Load(object sender, EventArgs e)
        {
            LoadOverallScores();
            LoadSubjects();
            LoadCategories();
        }

        
        private void LoadOverallScores()
        {
            listView1.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT subject_name, (assignment_score + quiz_score + test_score + midterm_score + final_score + project_score) AS OverallScore FROM tbl_subjects";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["subject_name"].ToString());
                        item.SubItems.Add(reader["OverallScore"].ToString());
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedSubject = listView1.SelectedItems[0].Text;
                LoadSubjectScores(selectedSubject);
            }
        }

        
        private void LoadSubjectScores(string subjectName)
        {
            listView2.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Task_name, Score FROM tbl_scoree WHERE subjectID = (SELECT subjectID FROM tbl_subjects WHERE subject_name = @subjectName)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Task_name"].ToString());
                        item.SubItems.Add(reader["Score"].ToString());
                        listView2.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading individual scores: {ex.Message}");
                }
            }
        }

        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                string taskName = listView2.SelectedItems[0].Text;
                DeleteScore(taskName);
                listView2.Items.Remove(listView2.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Please select a score to delete.");
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void DeleteScore(string taskName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM tbl_scoree WHERE Task_name = @taskName";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@taskName", taskName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Score deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting score: {ex.Message}");
                }
            }
        }

        
        private void LoadSubjects()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT subject_name FROM tbl_subjects";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["subject_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading subjects: {ex.Message}");
                }
            }
        }

        
        private void LoadCategories()
        {
            string[] categories = { "Assignment", "Quiz", "Test", "Midterm", "Final", "Project" };
            comboBox2.Items.AddRange(categories);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string subject = comboBox1.SelectedItem?.ToString();
            string category = comboBox2.SelectedItem?.ToString();
            string taskName = textBox1.Text;
            string scoreText = textBox2.Text;

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(scoreText))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!float.TryParse(scoreText, out float score))
            {
                MessageBox.Show("Please enter a valid numeric score.");
                return;
            }

            AddScore(subject, category, taskName, score);
        }

        private void AddScore(string subject, string category, string taskName, float score)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO tbl_scoree (subjectID, Task_name, Score) VALUES ((SELECT subjectID FROM tbl_subjects WHERE subject_name = @subject), @taskName, @score); UPDATE tbl_subjects  SET " + category.ToLower() + "_score = " + category.ToLower() + "_score + @score  WHERE subject_name = @subject";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@taskName", taskName);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Score added successfully.");
                    LoadOverallScores();
                    LoadSubjectScores(subject);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding score: {ex.Message}");
                }
            }
        }

        

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            Tracker Details = new Tracker();
            Details.Show();

            this.Close();
        }
    }
}