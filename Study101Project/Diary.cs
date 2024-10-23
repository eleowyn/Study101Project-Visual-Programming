using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Study101Project
{
    public partial class Diary : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        private int currentUserId = 1;

        public Diary()
        {
            InitializeComponent();
        }

        private void Diary_Load(object sender, EventArgs e)
        {
            LoadDiaryEntries();
        }

        private void LoadDiaryEntries()
        {
            Diary_List.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT diary_id, diary_title, diary_date FROM tbl_diary WHERE user_id = @userId ORDER BY diary_date DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string listItem = $"{reader["diary_date"].ToString()} - {reader["diary_title"].ToString()} - {reader["diary_id"].ToString()}";
                            Diary_List.Items.Add(listItem);
                        }
                    }
                }
            }
        }

        private void labelSaveDiary_Click(object sender, EventArgs e)
        {
            string title = textBoxName.Text;
            string content = textBox1.Text;
            DateTime date = dateDiary.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Please enter both title and content.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO tbl_diary (diary_title, diary_content, user_id, diary_date) VALUES (@title, @content, @userId, @date)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Diary entry saved successfully.");
            LoadDiaryEntries();
            ClearFields();
        }

        private void labelNewDiary_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            textBoxName.Clear();
            textBox1.Clear();
            dateDiary.Value = DateTime.Now;
        }

        private void Diary_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Diary_List.SelectedIndex != -1)
            {
                string selectedItem = Diary_List.SelectedItem.ToString();
                int diaryId = int.Parse(selectedItem.Split('-').Last().Trim());
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT diary_title, diary_content, diary_date FROM tbl_diary WHERE diary_id = @diaryId";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@diaryId", diaryId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxName.Text = reader["diary_title"].ToString();
                                textBox1.Text = reader["diary_content"].ToString();
                                dateDiary.Value = Convert.ToDateTime(reader["diary_date"]);
                            }
                        }
                    }
                }
            }
        }

        private void labelDeleteDiary_Click(object sender, EventArgs e)
        {
            if (Diary_List.SelectedIndex != -1)
            {
                string selectedItem = Diary_List.SelectedItem.ToString();
                int diaryId = int.Parse(selectedItem.Split('-').Last().Trim());

                if (MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM tbl_diary WHERE diary_id = @diaryId";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@diaryId", diaryId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Diary entry deleted successfully.");
                    LoadDiaryEntries();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select an entry to delete.");
            }
        }

        private void labelBackDiary_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
        private void dateDiary_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void labelClearDiary_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}