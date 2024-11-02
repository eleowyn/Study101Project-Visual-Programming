using System;
using System.Windows.Forms;

namespace Study101Project
{
    public partial class AddFlashcardForm : Form
    {
        public AddFlashcardForm()
        {
            InitializeComponent();
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
                this.DialogResult = DialogResult.OK;
                this.Close();
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

