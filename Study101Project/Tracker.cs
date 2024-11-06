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

        public Tracker()
        {
            InitializeComponent();
            LoadSubjects();
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
            listBox1.Items.Clear();
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
                        listBox1.Items.Add(reader["subject_name"].ToString());
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

        private void textBoxSubject_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Tracker_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelSubject_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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
    }
}