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
    public partial class UserControlDays : UserControl
    {
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            
        }

        public void days(int numday)
        {
            label1Bdays.Text = numday.ToString();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = label1Bdays.Text;
            addevent eventform = new addevent();
            eventform.Show();
        }
    }
}
