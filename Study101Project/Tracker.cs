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
    public partial class Tracker : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private string selectedSubject = null;

        public Tracker()
        {
            InitializeComponent();
            InitializeFlowLayoutPanels();
            LoadSubjects();
        }

        private void InitializeFlowLayoutPanels()
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.WrapContents = false;
            flowLayoutPanel4.AutoScroll = true;
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Padding = new Padding(10);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string subjectName = textBoxSubject.Text;

            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Please enter a subject name.");
                return;
            }

            float assignmentWeight = (float)numericUpDownAssignment.Value;
            float quizWeight = (float)numericUpDownQuiz.Value;
            float testWeight = (float)numericUpDownTest.Value;
            float midWeight = (float)numericUpDownMid.Value;
            float finalWeight = (float)numericUpDownFinal.Value;
            float projectWeight = (float)numericUpDownProject.Value;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO tbl_subjects (user_id, subject_name, assignment_weight, quiz_weight, test_weight, mid_weight, 
                             final_weight, project_weight) 
                             VALUES (@userId, @subjectName, @assignmentWeight, @quizWeight, @testWeight, @midWeight, 
                             @finalWeight, @projectWeight)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    cmd.Parameters.AddWithValue("@assignmentWeight", assignmentWeight);
                    cmd.Parameters.AddWithValue("@quizWeight", quizWeight);
                    cmd.Parameters.AddWithValue("@testWeight", testWeight);
                    cmd.Parameters.AddWithValue("@midWeight", midWeight);
                    cmd.Parameters.AddWithValue("@finalWeight", finalWeight);
                    cmd.Parameters.AddWithValue("@projectWeight", projectWeight);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Subject and weights added successfully!");
                    LoadSubjects();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadSubjects()
        {
            flowLayoutPanel1.Controls.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT subject_name FROM tbl_subjects WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string subjectName = reader["subject_name"].ToString();
                        Button subjectButton = new Button
                        {
                            Text = subjectName,
                            AutoSize = true,
                            Margin = new Padding(5),
                            Font = new Font("Century Gothic", 8, FontStyle.Regular),
                            BackColor = Color.FloralWhite,
                            FlatStyle = FlatStyle.Flat,
                        };
                        subjectButton.Click += (sender, e) =>
                        {
                            LoadSubjectWeights(subjectName);
                            selectedSubject = subjectName;
                            foreach (Control ctrl in flowLayoutPanel1.Controls)
                            {
                                if (ctrl is Button btn)
                                {
                                    btn.BackColor = (btn == subjectButton) ? Color.LightBlue : Color.FloralWhite;
                                }
                            }
                        };

                        flowLayoutPanel1.Controls.Add(subjectButton);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subjects: " + ex.Message);
                }
            }
        }

        private void ClearInputs()
        {
            textBoxSubject.Clear();
            numericUpDownAssignment.Value = numericUpDownAssignment.Minimum;
            numericUpDownQuiz.Value = numericUpDownQuiz.Minimum;
            numericUpDownTest.Value = numericUpDownTest.Minimum;
            numericUpDownMid.Value = numericUpDownMid.Minimum;
            numericUpDownFinal.Value = numericUpDownFinal.Minimum;
            numericUpDownProject.Value = numericUpDownProject.Minimum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Details details = new Details();
            details.Show();
            this.Close();
        }

        private void LoadSubjectWeights(string subjectName)
        {
            flowLayoutPanel4.Controls.Clear();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT assignment_weight, quiz_weight, test_weight, mid_weight, 
                           final_weight, project_weight 
                           FROM tbl_subjects 
                           WHERE user_id = @userId AND subject_name = @subjectName";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string[] categories = { "Assignment", "Quiz", "Test", "Midterm", "Final", "Project" };
                        float[] weights = {
                            Convert.ToSingle(reader["assignment_weight"]),
                            Convert.ToSingle(reader["quiz_weight"]),
                            Convert.ToSingle(reader["test_weight"]),
                            Convert.ToSingle(reader["mid_weight"]),
                            Convert.ToSingle(reader["final_weight"]),
                            Convert.ToSingle(reader["project_weight"])
                        };

                        ListView listView = new ListView
                        {
                            View = View.Details,
                            Width = flowLayoutPanel4.Width - 20,
                            Height = flowLayoutPanel4.Height - 20,
                            Font = new Font("Century Gothic", 10, FontStyle.Regular),
                            BackColor = Color.MistyRose,
                            Visible = true
                        };

                        listView.Columns.Add("Category", 150);
                        listView.Columns.Add("Weight (%)", 100);

                        for (int i = 0; i < categories.Length; i++)
                        {
                            ListViewItem item = new ListViewItem(categories[i]);
                            item.SubItems.Add(weights[i].ToString("F2") + "%");
                            listView.Items.Add(item);
                        }

                        flowLayoutPanel4.Controls.Add(listView);
                        listView.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("No weights found for subject: " + subjectName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading subject weights: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSubject))
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the subject '{selectedSubject}' and all its contents?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string deleteContentsQuery = @"DELETE FROM tbl_score WHERE subject_id = 
                                               (SELECT subject_id FROM tbl_subjects WHERE subject_name = @subjectName AND user_id = @userId)";
                        MySqlCommand deleteContentsCmd = new MySqlCommand(deleteContentsQuery, connection);
                        deleteContentsCmd.Parameters.AddWithValue("@subjectName", selectedSubject);
                        deleteContentsCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                        deleteContentsCmd.ExecuteNonQuery();

                        string deleteSubjectQuery = "DELETE FROM tbl_subjects WHERE subject_name = @subjectName AND user_id = @userId";
                        MySqlCommand deleteSubjectCmd = new MySqlCommand(deleteSubjectQuery, connection);
                        deleteSubjectCmd.Parameters.AddWithValue("@subjectName", selectedSubject);
                        deleteSubjectCmd.Parameters.AddWithValue("@userId", UserSession.user_id);
                        deleteSubjectCmd.ExecuteNonQuery();

                        MessageBox.Show($"Subject '{selectedSubject}' and all its contents were deleted successfully!");

                        selectedSubject = null;

                        LoadSubjects();
                        flowLayoutPanel4.Controls.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting subject and its contents: {ex.Message}");
                    }
                }
            }
        }

        private void textBoxSubject_TextChanged(object sender, EventArgs e) {
        }
        private void Tracker_Load(object sender, EventArgs e) {
        }
        private void label3_Click(object sender, EventArgs e) {
        }
        private void labelSubject_Click(object sender, EventArgs e) { 
        }
        private void label1_Click(object sender, EventArgs e) { 
        }
        private void label2_Click(object sender, EventArgs e) { 
        }
        private void label6_Click(object sender, EventArgs e) { 
        }
        private void label5_Click(object sender, EventArgs e) {
        }
        private void numericUpDownAssignment_ValueChanged(object sender, EventArgs e)
        {

        }
        private void numericUpDownQuiz_ValueChanged(object sender, EventArgs e) 
        {

        }
        private void numericUpDownTest_ValueChanged(object sender, EventArgs e) 
        {

        }
        private void numericUpDownMid_ValueChanged(object sender, EventArgs e)
        {

        }
        private void numericUpDownFinal_ValueChanged(object sender, EventArgs e) 
        {

        }
        private void numericUpDownProject_ValueChanged(object sender, EventArgs e) 
        {

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) 
        {

        }
        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e) 
        {

        }
    }
}