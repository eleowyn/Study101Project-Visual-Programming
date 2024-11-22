using System;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class AddFlashcardForm : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private int userId;

        public AddFlashcardForm()
        {
            InitializeComponent();
            userId = int.Parse(UserSession.user_id);
        }

        public string QuestionText
        {
            get { return txtQuestion.Text; }
        }

        public string AnswerText
        {
            get { return txtAnswer.Text; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text) || string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                MessageBox.Show("Please enter both a question and an answer.", "Incomplete Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    // Koneksi ke database
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Query untuk menambahkan data ke tbl_flashcard
                        string query = "INSERT INTO tbl_flashcard (question, answer, user_id) VALUES (@question, @answer, @userId)";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            // Mengatur parameter untuk query
                            cmd.Parameters.AddWithValue("@question", txtQuestion.Text);
                            cmd.Parameters.AddWithValue("@answer", txtAnswer.Text);
                            cmd.Parameters.AddWithValue("@userId", userId);

                            // Eksekusi query
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Menampilkan pesan sukses
                    MessageBox.Show("Flashcard has been successfully added to the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mengatur dialog result dan menutup form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Menampilkan pesan error jika terjadi kesalahan
                    MessageBox.Show("An error occurred while adding the flashcard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtQuestion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

