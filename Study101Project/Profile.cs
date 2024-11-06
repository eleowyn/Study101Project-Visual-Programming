using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class Profile : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private int userId;

        public Profile()
        {
            InitializeComponent();
            userId = int.Parse(UserSession.user_id);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadUserProfile();
        }


        private void LoadUserProfile()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT user_username, user_name, user_email FROM tbl_user WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUserID.Text = userId.ToString();
                                txtUsername.Text = reader["user_username"].ToString();
                                txtName.Text = reader["user_name"].ToString(); 
                                txtEmail.Text = reader["user_email"].ToString();

                                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text))
                                {
                                    MessageBox.Show("Please complete your profile by entering your name and email.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No user data found.");
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
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Name, Email, and Username cannot be empty. Please fill them in.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE tbl_user SET user_username = @userUsername, user_name = @userName, user_email = @userEmail WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userUsername", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@userName", txtName.Text);
                        cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Profile_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
