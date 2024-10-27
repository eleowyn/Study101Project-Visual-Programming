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
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            Daydetails dayDetailsForm = new Daydetails();
            dayDetailsForm.ShowDialog();
            this.Close(); // Close the Choose form
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addevent addEventForm = new addevent();
            addEventForm.ShowDialog();
            this.Close();
        }
    }
}
