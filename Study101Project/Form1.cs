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

namespace Study101Project
{
    public partial class Form1 : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public class UserSession
        {
            public static string user_username { get; set; }
            public static string user_id { get; set; }
            public static string user_name { get; set; }
            public static string user_email { get; set; }
            public static string user_password { get; set; }

            public static void SetUserData(string userName, string userId, string username, string userEmail, string userPassword)
            {
                user_username = userName;
                user_id = userId;
                user_name = username;
                user_email = userEmail;
            }
        }

        public Form1()
        {
            alamat = "server=localhost; database=db_study101; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = txtUsername.Text.Trim();
                query = string.Format("SELECT * FROM tbl_user WHERE user_username = '{0}' OR user_email = '{0}'", userInput);
                ds.Clear();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                adapter.Fill(ds);
                koneksi.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow kolom = ds.Tables[0].Rows[0];
                    string sandi = kolom["user_password"].ToString();

                    if (sandi == txtPassword.Text)
                    {

                        UserSession.user_password = kolom["user_password"].ToString();
                        UserSession.user_email = kolom["user_email"].ToString();
                        UserSession.user_username = kolom["user_username"].ToString();
                        UserSession.user_name = kolom["user_name"].ToString();
                        UserSession.user_id = kolom["user_id"].ToString();

                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Email Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btbClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSignin_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn();
            signin.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
