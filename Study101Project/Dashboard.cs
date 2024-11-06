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
using static Study101Project.Form1;

namespace Study101Project
{
    public partial class Dashboard : Form
    {
        private string connectionString = "server=localhost; database=db_study101; username=root; password=;";
        public Dashboard()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(DrawLine);
            CustomizeDataGridView();
            LoadTasks();
        }
        private void DrawLine(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black, 1);
            g.DrawLine(myPen, 50, 50, 300, 50);
            myPen.Dispose();
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            STechnique Dashboard = new STechnique();
            Dashboard.Show();

            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            TodoList Dashboard = new TodoList();
            Dashboard.Show();

            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            Calender Dashboard = new Calender();
            Dashboard.Show();

            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Tracker Dashboard = new Tracker();
            Dashboard.Show();

            this.Close();
        }

        private void labelProfile_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile();
            profileForm.Show();
            this.Hide();
        }

        private void labelDiary_Click(object sender, EventArgs e)
        {
            Diary Dashboard = new Diary();
            Dashboard.Show();

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelGames_Click(object sender, EventArgs e)
        {
            Game Dashboard = new Game();
            Dashboard.Show();

            this.Close();
        }


        private void CustomizeDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersVisible = false; 
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ScrollBars = ScrollBars.None;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 230);
            dataGridView1.DefaultCellStyle.Padding = new Padding(10);

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("task_title", "Task Title");
            dataGridView1.Columns.Add("task_duedate", "Due Date");

            dataGridView1.Columns["task_title"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridView1.Columns["task_duedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
            dataGridView1.RowTemplate.Height = 60;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }


        private void LoadTasks()
        {
            dataGridView1.Rows.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT task_title, task_duedate, task_type FROM tbl_task WHERE user_id = @userId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.user_id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["task_title"].ToString(),
                                Convert.ToDateTime(reader["task_duedate"]).ToShortDateString(),
                                reader["task_type"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tasks: " + ex.Message);
                }
            }
        }
    }
}
