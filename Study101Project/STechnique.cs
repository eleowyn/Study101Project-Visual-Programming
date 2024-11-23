using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using static Study101Project.Form1;



namespace Study101Project
{
    public partial class STechnique : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private string userId;

        private int hours;
        private int minutes;
        private int seconds;
        private int trig = 0;
        //private List<Flashcard> flashcards;
        private int currentIndex = 0;

        public STechnique()
        {
            InitializeComponent();
            //flashcards = new List<Flashcard>();
            DisplayFlashcard();
        }

        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void labelMinutes_Click(object sender, EventArgs e)
        {

        }

        

        //public class Flashcard
        //{
        //    public string Question { get; set; }
        //    public string Answer { get; set; }

        //    public Flashcard(string question, string answer)
        //    {
        //        Question = question;
        //        Answer = answer;
        //    }
        //}

        //private void DisplayFlashcard()
        //{
        //    if (flashcards.Count > 0)
        //    {
        //        lblQuestion.Text = flashcards[currentIndex].Question;
        //        lblAnswer.Text = "";
        //    }
        //    else
        //    {
        //        lblQuestion.Text = "No flashcards available. Please add a flashcard.";
        //        lblAnswer.Text = "";
        //    }
        //}


        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    if (flashcards.Count > 0)
        //    {
        //        currentIndex = (currentIndex + 1) % flashcards.Count;
        //        DisplayFlashcard();
        //    }
        //}

        //private void btnPrevious_Click(object sender, EventArgs e)
        //{
        //    if (flashcards.Count > 0)
        //    {
        //        currentIndex = (currentIndex - 1 + flashcards.Count) % flashcards.Count;
        //        DisplayFlashcard();
        //    }
        //}


        //private void btnFlip_Click(object sender, EventArgs e)
        //{
        //    if (flashcards.Count > 0)
        //    {
        //        lblAnswer.Text = flashcards[currentIndex].Answer;
        //    }
        //    else
        //    {
        //        lblAnswer.Text = "No answer available. Please add a flashcard.";
        //    }
        //}


        private void DisplayFlashcard()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Query untuk mengambil data Question dan Answer berdasarkan user_id dan currentIndex
                    string query = "SELECT Question, Answer FROM tbl_flashcard WHERE user_id = @userId LIMIT 1 OFFSET @offset";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);  // Menggunakan user_id untuk mengambil flashcards milik pengguna
                    cmd.Parameters.AddWithValue("@offset", currentIndex);  // Menggunakan currentIndex untuk menavigasi data flashcards

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())  // Jika data ditemukan
                        {
                            lblQuestion.Text = reader.GetString("Question");  // Menampilkan Question dari database
                            lblAnswer.Text = "";  // Menampilkan Answer kosong, akan ditampilkan nanti dengan tombol flip
                        }
                        else
                        {
                            lblQuestion.Text = "No data available.";  // Jika tidak ada data
                            lblAnswer.Text = "No data available.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblQuestion.Text = "Error loading flashcards.";  // Menampilkan pesan error
                    lblAnswer.Text = ex.Message;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalFlashcards = GetFlashcardCountFromDatabase();  // Mengambil jumlah total flashcards dari database

            if (totalFlashcards > 0)
            {
                currentIndex = (currentIndex + 1) % totalFlashcards;  // Menavigasi ke flashcard berikutnya
                DisplayFlashcard();  // Menampilkan flashcard berdasarkan index baru
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int totalFlashcards = GetFlashcardCountFromDatabase();  // Mengambil jumlah total flashcards dari database

            if (totalFlashcards > 0)
            {
                currentIndex = (currentIndex - 1 + totalFlashcards) % totalFlashcards;  // Menavigasi ke flashcard sebelumnya
                DisplayFlashcard();  // Menampilkan flashcard berdasarkan index baru
            }
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0)  // Pastikan currentIndex valid
            {
                string answer = GetFlashcardAnswerFromDatabase(currentIndex);  // Mengambil answer flashcard dari database
                lblAnswer.Text = answer;  // Menampilkan answer di label
            }
            else
            {
                lblAnswer.Text = "No answer available.";  // Menampilkan pesan jika tidak ada answer
            }
        }

        //tambah fungsi baru
        private int GetFlashcardCountFromDatabase()
        {
            int count = 0;
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tbl_flashcard WHERE user_id = @userId";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);  // Filter berdasarkan user_id

                    count = Convert.ToInt32(cmd.ExecuteScalar());  // Mengambil hasil dari query (jumlah flashcards)
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return count;
        }

        private string GetFlashcardAnswerFromDatabase(int index)
        {
            string answer = "";
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Answer FROM tbl_flashcard WHERE user_id = @userId LIMIT 1 OFFSET @offset";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);  // Filter berdasarkan user_id
                    cmd.Parameters.AddWithValue("@offset", index);   // Mengambil data berdasarkan index (currentIndex)

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())  // Jika ada data ditemukan
                        {
                            answer = reader.GetString("Answer");  // Mengambil nilai Answer dari database
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return answer;
        }




        private void btnAddFlashcard_Click(object sender, EventArgs e)
        {
            AddFlashcardForm addFlashcardForm = new AddFlashcardForm();
            addFlashcardForm.Show();
        }


        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void lblAnswer_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (timer4.Enabled)
            {
                timer4.Stop();
                btnPause.Text = "Resume";
            }
            else
            {
                timer4.Start();
                btnPause.Text = "Pause";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            hours = Convert.ToInt32(Math.Round(numericUpDownHours.Value, 0));
            minutes = Convert.ToInt32(Math.Round(numericUpDownMinutes.Value, 0));
            seconds = Convert.ToInt32(Math.Round(numericUpDownSeconds.Value, 0));

            labelJam.Text = hours.ToString();
            labelMenit.Text = minutes.ToString();
            labelDetik.Text = seconds.ToString();

            if (trig == 0)
            {
                timer4 = new Timer();
                timer4.Tick += new EventHandler(timer4_Tick);
                timer4.Interval = 1000;
                trig = 1;
            }
            timer4.Start();
        }

        private void labelJam_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer4.Stop();
            hours = 0;
            minutes = 0;
            seconds = 0;
            labelJam.Text = hours.ToString();
            labelMenit.Text = minutes.ToString();
            labelDetik.Text = seconds.ToString();
            btnPause.Text = "Pause";
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds <= 0)
            {
                if (minutes > 0 || hours > 0)
                {
                    if (minutes == 0)
                    {
                        if (hours >= 0)
                        {
                            hours = hours - 1;
                            minutes = 60;
                            if (hours < 0)
                            {
                                hours = 0;
                            }
                        }
                    }
                    minutes = minutes - 1;
                    seconds = 59;
                    timer4 = new Timer();
                    timer4.Interval = 1000;
                    timer4.Start();
                    labelJam.Text = hours.ToString();
                    labelMenit.Text = minutes.ToString();
                    labelDetik.Text = seconds.ToString();
                    if (minutes < 0)
                    {
                        minutes = 0;
                    }

                }
                if (seconds < 0)
                {
                    seconds = 0;
                }
                timer4.Stop();
            }
            labelJam.Text = hours.ToString();
            labelMenit.Text = minutes.ToString();
            labelDetik.Text = seconds.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard STechnique = new Dashboard();
            STechnique.Show();

            this.Close();
        }

        private void print_Click(object sender, EventArgs e)
        {
            CREPORT CReport = new CREPORT();
            CReport.Show();

            this.Close();
        }
    }
}
