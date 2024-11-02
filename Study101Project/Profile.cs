using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study101Project
{
    public partial class Profile : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private int userId; // Assuming this is set after the user logs in

        public Profile()
        {
            InitializeComponent();
            
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadUserProfile(); // Load user profile on form load
        }

        private void LoadUserProfile()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT user_name, user_email FROM tbl_user WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["user_name"].ToString(); // Display the username
                                txtEmail.Text = reader["user_email"].ToString();  // Display the email if it exists
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE tbl_user SET user_name = @userName, user_email = @userEmail WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userName", txtUsername.Text); // Update the username
                        cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);   // Update the email
                        cmd.Parameters.AddWithValue("@userId", userId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Profile updated successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Leave empty or add code if needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Leave empty or add code if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();

            this.Close();
        }

    }
}