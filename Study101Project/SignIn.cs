using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study101Project
{
    public partial class SignIn : Form
    {
        private string connectionString = "server=127.0.0.1;database=db_study101;uid=root;pwd=;";

        public SignIn()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void lblSignin_Click(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click_1(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM tbl_user WHERE user_username = @username";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int usernameExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (usernameExists > 0)
                        {
                            MessageBox.Show("Username already exists. Please choose a different username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO tbl_user (user_name, user_username, user_email, user_password) " +
                                   "VALUES (@name, @username, @email, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully! Redirecting to login...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Account creation failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void lblLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
