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
    public partial class Calender : Form
    {
        int month, year;
        public static string static_month, static_year;

        public Calender()
        {
            InitializeComponent();
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            
            displayDays(month, year);
        }

        private void displayDays(int month, int year)
        {
            daycontainer.Controls.Clear();
            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = (int)startofthemonth.DayOfWeek;
            for (int i = 0; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);  
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            
            month++;
            if (month > 12)
            {
                month = 1;  
                year++;     
            }

            
            displayDays(month, year);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            
            month--;
            if (month < 1)
            {
                month = 12;  
                year--;      
            }

            
            displayDays(month, year);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
