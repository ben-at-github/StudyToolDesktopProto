using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyToolReader;

namespace StudyTool
{
    public partial class NewQuestionForm : Form
    {

        public bool Canceled { get; private set; }
        public Question Question { get; private set; }

        public NewQuestionForm()
        {
            InitializeComponent();
            this.Canceled = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            bool error = false;
            string msg = "";
            if (String.IsNullOrWhiteSpace(this.textBoxQuestion.Text))
            {
                error = true;
                msg += "A question is required.  ";
            }
            if (String.IsNullOrWhiteSpace(this.textBoxAnswer.Text))
            {
                error = true;
                msg += "A answer is required.";
            }
            if (error)
            {
                MessageBox.Show(msg, "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Canceled = false;
            this.Question =  new Question(this.textBoxQuestion.Text, this.textBoxAnswer.Text);

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
