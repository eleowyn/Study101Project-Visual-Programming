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
    public partial class STechnique : Form
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int trig = 0;
        public STechnique()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void labelMinutes_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            hours = Convert.ToInt32(Math.Round(numericUpDownHours.Value, 0));
            minutes = Convert.ToInt32(Math.Round(numericUpDownMinutes.Value, 0));
            seconds = Convert.ToInt32(Math.Round(numericUpDownSeconds.Value, 0));

            labelJam.Text = hours.ToString();
            labelMenit.Text = minutes.ToString();
            labelDetik.Text = minutes.ToString();

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
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds <= 0)
            {
                if(minutes > 0 || hours > 0)
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
                if (seconds <  0)
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
    }
}
