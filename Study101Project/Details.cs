using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class Details : Form
    {

        private string connectionString = "Server=127.0.0.1;Database=db_study101;Uid=root;Pwd=;";

        public Details()
        {
            InitializeComponent();
        }

        private void InitializeListViews()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Subject", 150);
            listView1.Columns.Add("Overall Score", 100);

            listView2.View = View.Details;
            listView2.Columns.Add("Category", 150);
            listView2.Columns.Add("Overall Score", 100);
        }
        private void Details_Load(object sender, EventArgs e)
        {

            LoadSubjects();
            LoadCategories();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjectScores();
        }

        private void LoadOverallScores()
        {
            listView1.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT subject_name, 
                                    SUM(CASE WHEN subject_type = 'Assignment' THEN score END) AS assignment_score,
                                    SUM(CASE WHEN subject_type = 'Quiz' THEN score END) AS quiz_score,
                                    SUM(CASE WHEN subject_type = 'Test' THEN score END) AS test_score,
                                    SUM(CASE WHEN subject_type = 'Midterm' THEN score END) AS midterm_score,
                                    SUM(CASE WHEN subject_type = 'Final' THEN score END) AS final_score,
                                    SUM(CASE WHEN subject_type = 'Project' THEN score END) AS project_score
                             FROM tbl_scoree WHERE user_id = @userId GROUP BY subject_name";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        float assignmentScore = reader["assignment_score"] != DBNull.Value ? Convert.ToSingle(reader["assignment_score"]) : 0;
                        float quizScore = reader["quiz_score"] != DBNull.Value ? Convert.ToSingle(reader["quiz_score"]) : 0;
                        float testScore = reader["test_score"] != DBNull.Value ? Convert.ToSingle(reader["test_score"]) : 0;
                        float midtermScore = reader["midterm_score"] != DBNull.Value ? Convert.ToSingle(reader["midterm_score"]) : 0;
                        float finalScore = reader["final_score"] != DBNull.Value ? Convert.ToSingle(reader["final_score"]) : 0;
                        float projectScore = reader["project_score"] != DBNull.Value ? Convert.ToSingle(reader["project_score"]) : 0;

                        // Calculate weighted score
                        float overallScore = (assignmentScore * 0.2f) + (quizScore * 0.1f) + (testScore * 0.2f) +
                                             (midtermScore * 0.2f) + (finalScore * 0.2f) + (projectScore * 0.1f);

                        ListViewItem item = new ListViewItem(subjectName);
                        item.SubItems.Add($"{overallScore:0.00}%");
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        private void LoadSubjectScores()
        {
            listView2.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT SUM(assignment_score * assignment_weight) AS Assignment, 
                                    SUM(quiz_score * quiz_weight) AS Quiz, 
                                    SUM(test_score * test_weight) AS Test, 
                                    SUM(midterm_score * mid_weight) AS Midterm, 
                                    SUM(final_score * final_weight) AS Final, 
                                    SUM(project_score * project_weight) AS Project 
                             FROM tbl_subjects WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        listView2.Items.Add(new ListViewItem(new[] { "Assignment", $"{reader["Assignment"]:0.00}%" }));
                        listView2.Items.Add(new ListViewItem(new[] { "Quiz", $"{reader["Quiz"]:0.00}%" }));
                        listView2.Items.Add(new ListViewItem(new[] { "Test", $"{reader["Test"]:0.00}%" }));
                        listView2.Items.Add(new ListViewItem(new[] { "Midterm", $"{reader["Midterm"]:0.00}%" }));
                        listView2.Items.Add(new ListViewItem(new[] { "Final", $"{reader["Final"]:0.00}%" }));
                        listView2.Items.Add(new ListViewItem(new[] { "Project", $"{reader["Project"]:0.00}%" }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading category scores: {ex.Message}");
                }
            }
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
                    string insertScoreQuery = @"INSERT INTO tbl_scoree (subject_name, subject_type, task_name, score, user_id) 
                                        VALUES (@subject, @category, @taskName, @score, @userId)";
                    MySqlCommand insertCmd = new MySqlCommand(insertScoreQuery, conn);
                    insertCmd.Parameters.AddWithValue("@subject", subject);
                    insertCmd.Parameters.AddWithValue("@category", category);
                    insertCmd.Parameters.AddWithValue("@taskName", taskName);
                    insertCmd.Parameters.AddWithValue("@score", score);
                    insertCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Score added successfully.");
                    LoadOverallScores();
                    LoadSubjectScores();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjectScores();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjectScores();
        }
    }
}
