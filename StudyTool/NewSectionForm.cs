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
    public partial class NewSectionForm : Form
    {

        public bool Canceled { get; private set; }

        public Questions questions { get; private set; }

        public NewSectionForm()
        {
            InitializeComponent();
            this.Canceled = true;
            this.questions = new Questions();
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            NewQuestionForm nqf = new NewQuestionForm();
            nqf.ShowDialog(this);
            
            if (!nqf.Canceled)
                this.questions.questions.Add(nqf.Question);

            return;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.textBoxName.Text))
            {
                MessageBox.Show("Please enter a name", "A Name Is Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Canceled = false;
            this.questions.section = this.textBoxName.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
