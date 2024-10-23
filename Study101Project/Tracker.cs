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
            string category = comboBoxCategory.SelectedItem.ToString();
            int score = (int)numericUpDown1.Value;

            if (string.IsNullOrWhiteSpace(subjectName) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please enter a subject name and select a category.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tbl_subjects (subject_name, " + category.ToLower() + "_score) VALUES (@subjectName, @score)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Subject added successfully!");
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
                    string query = "SELECT subject_name FROM tbl_subjects";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
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
            comboBoxCategory.SelectedIndex = -1;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Details details = new Details();
            details.Show();
            this.Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}