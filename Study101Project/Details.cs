﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
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
            InitializeListViews();
        }

        private void InitializeListViews()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Font = new Font("Century Gothic", 10);
            listView1.Columns.Add("Subject", 200);
            listView1.Columns.Add("Overall Score", 120);

            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Font = new Font("Century Gothic", 10);
            listView2.Columns.Add("Category", 150);
            listView2.Columns.Add("Task Name",150);
            listView2.Columns.Add("Score", 100);
            listView2.Columns.Add("Weight", 100);
            listView2.Columns.Add("Weighted Score", 120);
        }

        private void Details_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadCategories();
            LoadOverallScores();

            if (listView1.Items.Count > 0)
            {
                LoadSubjectDetails(listView1.Items[0].Text);
            }
        }

        private void LoadSubjects()
        {
            comboBox1.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT subject_name FROM tbl_subjects WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            string subjectName = reader["subject_name"].ToString();
                            comboBox1.Items.Add(subjectName);
                            count++;
                        }
                        MessageBox.Show($"Loaded {count} subjects");
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
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedSubject = listView1.SelectedItems[0].Text;
                LoadSubjectDetails(selectedSubject);
            }
        }

        private void LoadSubjectDetails(string subjectName)
        {
            listView2.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); string query = @"
                        SELECT 
                            sc.subject_type,
                            sc.task_name,
                            sc.score,
                            CASE 
                                WHEN sc.subject_type = 'Assignment' THEN s.assignment_weight
                                WHEN sc.subject_type = 'Quiz' THEN s.quiz_weight
                                WHEN sc.subject_type = 'Test' THEN s.test_weight
                                WHEN sc.subject_type = 'Midterm' THEN s.mid_weight
                                WHEN sc.subject_type = 'Final' THEN s.final_weight
                                WHEN sc.subject_type = 'Project' THEN s.project_weight
                            END as weight
                        FROM tbl_score sc
                        JOIN tbl_subjects s ON s.subject_id = sc.subject_id
                        WHERE s.subject_name = @subjectName 
                        AND sc.user_id = @userId
                        ORDER BY sc.subject_type, sc.task_name";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["subject_type"].ToString();
                            string taskName = reader["task_name"].ToString();
                            float score = Convert.ToSingle(reader["score"]);
                            float weight = Convert.ToSingle(reader["weight"]);
                            float weightedScore = score * (weight / 100);

                            Console.WriteLine($"Loading: Category={category}, Task={taskName}, Score={score}, Weight={weight}");

                            ListViewItem item = new ListViewItem(new[]
                            {
                        category,
                        taskName,
                        $"{score:F2}%",
                        $"{weight:F2}%",
                        $"{weightedScore:F2}%"
                    });

                            item.BackColor = GetCategoryColor(category);
                            listView2.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading subject details: {ex.Message}");
                }
            }
        }

        private Color GetCategoryColor(string category)
        {
            switch (category)
            {
                case "Assignment":
                    return Color.FromArgb(255, 240, 240);
                case "Quiz":
                    return Color.FromArgb(240, 255, 240);
                case "Test":
                    return Color.FromArgb(240, 240, 255);
                case "Midterm":
                    return Color.FromArgb(255, 255, 240);
                case "Final":
                    return Color.FromArgb(255, 240, 255);
                case "Project":
                    return Color.FromArgb(240, 255, 255);
                default:
                    return Color.White;
            }
        }



        private void LoadOverallScores()
        {
            listView1.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        s.subject_name,
                        s.assignment_weight,
                        s.quiz_weight,
                        s.test_weight,
                        s.mid_weight,
                        s.final_weight,
                        s.project_weight,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Assignment' AND user_id = @userId) as avg_assignment,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Quiz' AND user_id = @userId) as avg_quiz,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Test' AND user_id = @userId) as avg_test,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Midterm' AND user_id = @userId) as avg_midterm,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Final' AND user_id = @userId) as avg_final,
                        (SELECT AVG(score) FROM tbl_score WHERE subject_name = s.subject_name AND subject_type = 'Project' AND user_id = @userId) as avg_project
                    FROM tbl_subjects s
                    WHERE s.user_id = @userId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();

                        float assignmentWeight = Convert.ToSingle(reader["assignment_weight"]) / 100;
                        float quizWeight = Convert.ToSingle(reader["quiz_weight"]) / 100;
                        float testWeight = Convert.ToSingle(reader["test_weight"]) / 100;
                        float midWeight = Convert.ToSingle(reader["mid_weight"]) / 100;
                        float finalWeight = Convert.ToSingle(reader["final_weight"]) / 100;
                        float projectWeight = Convert.ToSingle(reader["project_weight"]) / 100;

                        float assignmentScore = reader["avg_assignment"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_assignment"]);
                        float quizScore = reader["avg_quiz"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_quiz"]);
                        float testScore = reader["avg_test"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_test"]);
                        float midtermScore = reader["avg_midterm"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_midterm"]);
                        float finalScore = reader["avg_final"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_final"]);
                        float projectScore = reader["avg_project"] == DBNull.Value ? 0 : Convert.ToSingle(reader["avg_project"]);

                        float overallScore = (assignmentScore * assignmentWeight) +
                                           (quizScore * quizWeight) +
                                           (testScore * testWeight) +
                                           (midtermScore * midWeight) +
                                           (finalScore * finalWeight) +
                                           (projectScore * projectWeight);

                        ListViewItem item = new ListViewItem(subjectName);
                        item.SubItems.Add($"{overallScore:F2}%");
                        item.Tag = subjectName;
                        listView1.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading overall scores: {ex.Message}");
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
            string taskName = textBox1.Text.ToString();
            string scoreText = textBox2.Text;

            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(category) ||
                string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(scoreText))
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

            LoadOverallScores();
            if (listView1.SelectedItems.Count > 0)
            {
                LoadSubjectDetails(listView1.SelectedItems[0].Text);
            }
        }

        private void AddScore(string subject, string category, string taskName, float score)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // First get the subject_id
                    string getSubjectIdQuery = "SELECT subject_id FROM tbl_subjects WHERE subject_name = @subject AND user_id = @userId";
                    MySqlCommand getSubjectCmd = new MySqlCommand(getSubjectIdQuery, conn);
                    getSubjectCmd.Parameters.AddWithValue("@subject", subject);
                    getSubjectCmd.Parameters.AddWithValue("@userId", UserSession.user_id);

                    object result = getSubjectCmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Subject not found!");
                        return;
                    }

                    int subjectId = Convert.ToInt32(result);

                    string insertScoreQuery = @"INSERT INTO tbl_score
                (subject_id, subject_name, subject_type, task_name, score, user_id) 
                VALUES 
                (@subjectId, @subject, @category, @taskName, @score, @userId)";

                    MySqlCommand insertCmd = new MySqlCommand(insertScoreQuery, conn);
                    insertCmd.Parameters.AddWithValue("@subjectId", subjectId);
                    insertCmd.Parameters.AddWithValue("@subject", subject);
                    insertCmd.Parameters.AddWithValue("@category", category);
                    insertCmd.Parameters.AddWithValue("@taskName", taskName);
                    insertCmd.Parameters.AddWithValue("@score", score);
                    insertCmd.Parameters.AddWithValue("@userId", UserSession.user_id);

                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Score added successfully!");
                    }
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (listView1.SelectedItems.Count > 0 && listView2.SelectedItems.Count == 0)
                    {
                        string subjectName = listView1.SelectedItems[0].Text;

                        string deleteTasksQuery = "DELETE FROM tbl_score WHERE subject_name = @subjectName AND user_id = @userId";
                        MySqlCommand deleteTasksCmd = new MySqlCommand(deleteTasksQuery, conn);
                        deleteTasksCmd.Parameters.AddWithValue("@subjectName", subjectName);
                        deleteTasksCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                        deleteTasksCmd.ExecuteNonQuery();

                        string deleteSubjectQuery = "DELETE FROM tbl_subjects WHERE subject_name = @subjectName AND user_id = @userId";
                        MySqlCommand deleteSubjectCmd = new MySqlCommand(deleteSubjectQuery, conn);
                        deleteSubjectCmd.Parameters.AddWithValue("@subjectName", subjectName);
                        deleteSubjectCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                        deleteSubjectCmd.ExecuteNonQuery();

                        listView1.Items.Remove(listView1.SelectedItems[0]);
                        MessageBox.Show("Subject and all associated tasks deleted successfully!");
                    }
                    else if (listView2.SelectedItems.Count > 0)
                    {
                        string subjectType = listView2.SelectedItems[0].SubItems[0].Text;
                        string taskName = listView2.SelectedItems[0].SubItems[1].Text;

                        // Delete only the selected task
                        string deleteTaskQuery = "DELETE FROM tbl_score WHERE subject_type = @subjectType AND task_name = @taskName AND user_id = @userId";
                        MySqlCommand deleteTaskCmd = new MySqlCommand(deleteTaskQuery, conn);
                        deleteTaskCmd.Parameters.AddWithValue("@subjectType", subjectType);
                        deleteTaskCmd.Parameters.AddWithValue("@taskName", taskName);
                        deleteTaskCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                        deleteTaskCmd.ExecuteNonQuery();

                        listView2.Items.Remove(listView2.SelectedItems[0]);
                        MessageBox.Show("Task deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Please select a subject or task to delete.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item: {ex.Message}");
                }
            }
        }

        private void lblSubjectDetails_Click(object sender, EventArgs e)
        {

        }

        private void lblClick_Click(object sender, EventArgs e)
        {

        }

        private void lblSubject_Click(object sender, EventArgs e)
        {

        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }
    }
}
