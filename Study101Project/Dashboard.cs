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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(DrawLine);
        }
        private void DrawLine(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black, 1);
            g.DrawLine(myPen, 50, 50, 300, 50);
            myPen.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {
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

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
