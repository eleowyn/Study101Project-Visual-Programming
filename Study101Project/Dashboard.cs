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
            lblName.Text = $"Hi, {UserSession.user_name}!";
            CustomizeDataGridView();
            LoadTasks();
            DisplayRandomQuote();
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
            dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView1.ColumnHeadersVisible = false; 
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ScrollBars = ScrollBars.Horizontal;

            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FloralWhite;
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
            CustomizeRoundedDataGridView();
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
                            DateTime dueDate = Convert.ToDateTime(reader["task_duedate"]);
                            int rowIndex = dataGridView1.Rows.Add(
                                reader["task_title"].ToString(),
                                dueDate.ToShortDateString(),
                                reader["task_type"].ToString()
                            );

                            if (dueDate < DateTime.Now)
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                            }
                            else if ((dueDate - DateTime.Now).TotalDays < 7)
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            }
                            else
                            {
                                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tasks: " + ex.Message);
                }


            }
        }

        // Call this method in the Form Load or after initializing the DataGridView
        private void CustomizeRoundedDataGridView()
        {
            dataGridView1.BorderStyle = BorderStyle.None; // Remove default border

            // Attach the paint event handler
            dataGridView1.Paint += DataGridView1_Paint;
        }

        // Custom Paint event handler to create rounded corners
        private void DataGridView1_Paint(object sender, PaintEventArgs e)
        {
            // Create rounded rectangle path
            int radius = 20; // Adjust as needed for corner roundness
            int width = dataGridView1.Width;
            int height = dataGridView1.Height;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(width - radius, height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            // Set the clipping region for rounded edges
            dataGridView1.Region = new Region(path);

            // Draw a border around the DataGridView
            using (Pen pen = new Pen(Color.Gray, 2))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private List<string> quotes = new List<string>
        {
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Success is not the key to happiness. Happiness is the key to success. - Albert Schweitzer",
            "Don't watch the clock; do what it does. Keep going. - Sam Levenson",
            "The future depends on what you do today. - Mahatma Gandhi",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "You don’t have to be great to start, but you have to start to be great. - Zig Ziglar",
            "The way to get started is to quit talking and begin doing. - Walt Disney",
            "Success is not final, failure is not fatal: It is the courage to continue that counts. - Winston Churchill",
            "Productivity is never an accident. It is always the result of a commitment to excellence, intelligent planning, and focused effort. - Paul J. Meyer",
            "Education is the passport to the future, for tomorrow belongs to those who prepare for it today. - Malcolm X"
        };

        private void DisplayRandomQuote()
        {
            Random random = new Random();
            int index = random.Next(quotes.Count);
            textBox1.Text = quotes[index];
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
