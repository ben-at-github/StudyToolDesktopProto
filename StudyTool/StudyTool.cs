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
using System.IO;

namespace StudyTool
{
    
    public partial class StudyTool : Form
    {

        private Color HighlightColor = Color.Red;
        private Color HighlightBackColor = Color.Red;
        private int charsneeded = 2;
        private int questionsLoaded = 0;
        private FileSystemWatcher filewatcher;

        private Class c { get; set; }
        private Dictionary<int, Questions> questions { get; set; }
        

        public StudyTool()
        {
            Loader l = new Loader();
            l.ShowDialog(this);

            InitializeComponent();
            if (l.Canceled)
            {
                this.Close();
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            this.numericUpDownMinChars.Value = Convert.ToDecimal(Properties.Settings.Default.CharsNeeded);

            string filepath = l.selectedClass.filePath;
            if (File.Exists(filepath))
            {
                filewatcher = new FileSystemWatcher(Path.GetDirectoryName(filepath), Path.GetFileName(filepath));
                filewatcher.Changed += new FileSystemEventHandler(this.OnFileChange);
                filewatcher.EnableRaisingEvents = true;
            }

            this.questions = new Dictionary<int, Questions>();
            this.c = l.selectedClass;
            this.Text = c.name + " - Study Tool";
            foreach (Questions qs in this.c.questions)
                this.checkedListBoxSections.Items.Add(qs.section, CheckState.Unchecked);

            
            Cursor.Current = Cursors.Default;
            this.groupBoxData.Enabled = false;
        }

        private void LoadData()
        {
            Loader l = new Loader();
            l.ShowDialog(this);
            if (l.Canceled)
                return;


            this.c = l.selectedClass;
            this.RefreshData();

            return;
        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {
            this.richTextBoxAnswers.ResetText();
            
            if (this.textBoxQuestion.Text.Length > (this.charsneeded - 1))
            {
                foreach (KeyValuePair<int, Questions> qq in this.questions)
                {
                    var qs = from q in qq.Value.questions where q.a.Contains(this.textBoxQuestion.Text) || q.q.Contains(this.textBoxQuestion.Text) select q;
                    foreach (Question q in qs)
                        this.richTextBoxAnswers.Text += ("q: " + q.q + "\r\na: " + q.a + "\r\n\r\n");
                }
                
                if (this.checkBoxHighlight.Checked)
                    this.HighlighText();
            }

            return;
        }

        private void buttonViewQuestions_Click(object sender, EventArgs e)
        {
            this.richTextBoxAnswers.ResetText();
            foreach (KeyValuePair<int, Questions> qq in this.questions)
            {
                foreach (Question q in qq.Value.questions)
                    this.richTextBoxAnswers.Text += "q: " + q.q + "\r\na: " + q.a + "\r\n\r\n";
            }
        }

        private void buttonViewClass_Click(object sender, EventArgs e)
        {
            this.richTextBoxAnswers.ResetText();
            foreach (Questions qs in this.c.questions)
            {
                foreach (Question q in qs.questions)
                    this.richTextBoxAnswers.Text += "q: " + q.q + "\r\na: " + q.a + "\r\n\r\n";
            }
        }

        private void HighlighText()
        {
            int s_start = this.richTextBoxAnswers.SelectionStart, startIndex = 0, index;
            while ((index = this.richTextBoxAnswers.Text.IndexOf(this.textBoxQuestion.Text, startIndex)) != -1)
            {
                this.richTextBoxAnswers.Select(index, this.textBoxQuestion.Text.Length);
                //this.richTextBoxAnswers.SelectionColor = this.HighlightColor;
                this.richTextBoxAnswers.SelectionBackColor = this.HighlightBackColor;
                startIndex = index + this.textBoxQuestion.Text.Length;
            }

            this.richTextBoxAnswers.SelectionStart = s_start;
            this.richTextBoxAnswers.SelectionLength = 0;
        }

        private void loadNewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void buttonEditQuestion_Click(object sender, EventArgs e)
        {
            if (this.filewatcher != null)
                this.filewatcher.EnableRaisingEvents = false;

            EditQuestionForm eqf = new EditQuestionForm(this.c);
            eqf.ShowDialog(this);

            if (!eqf.Canceled)
            {
                this.c = eqf.c;
                this.RefreshData();
            }

            if (this.filewatcher != null)
                this.filewatcher.EnableRaisingEvents = true;
        }

        private void RefreshData()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.groupBoxData.Enabled = false;

            List<int> cidx = new List<int>();
            foreach (int idx in this.checkedListBoxSections.CheckedIndices)
                cidx.Add(idx);

            this.questionsLoaded = 0;
            this.Text = c.name + " - Study Tool";
            this.textBoxQuestion.ResetText();
            this.richTextBoxAnswers.ResetText();
            this.checkedListBoxSections.Items.Clear();
            foreach (Questions qs in this.c.questions)
                this.checkedListBoxSections.Items.Add(qs.section, CheckState.Unchecked);

            this.questions = new Dictionary<int, Questions>();
            foreach (int idx in cidx)
                this.checkedListBoxSections.SetItemCheckState(idx, CheckState.Checked);

            Cursor.Current = Cursors.Default;
        }

        private void RefreshClass()
        {
            if (!System.IO.File.Exists(this.c.filePath))
            {
                MessageBox.Show("Not able to reload class profile, file cannot be found.", "Unable To Load Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.c = new Class(this.c.filePath);
            RefreshData();
        }

        private void reloadClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshClass();
        }

        private void checkedListBoxSections_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.groupBoxData.Enabled = false;

            int add = 0;
            switch (e.CurrentValue)//old value
            {
                case CheckState.Unchecked://load the section
                    this.questions.Add(e.Index, this.c.questions[e.Index]);
                    this.questionsLoaded += this.c.questions[e.Index].questions.Count;
                    add = 1;
                    break;
                case CheckState.Checked://unload the section
                    this.questionsLoaded -= this.questions[e.Index].questions.Count;
                    this.questions.Remove(e.Index);
                    add = -1;
                    break;
                default:
                    return;
            }


            if ((this.checkedListBoxSections.CheckedIndices.Count + add) > 0)
            {
                this.groupBoxData.Enabled = true;
                this.groupBoxData.Text = "Loaded " + this.questionsLoaded.ToString() + " questions";
            }
            else
            {
                this.richTextBoxAnswers.ResetText();
                this.questionsLoaded = 0;
                this.groupBoxData.Text = "";
            }

        }

        private void OnFileChange(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                try
                {
                    this.filewatcher.EnableRaisingEvents = false;
                    var dialog = MessageBox.Show("Class has been modified outside this application.  Do you want to reload?", "Class Modified", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == System.Windows.Forms.DialogResult.Yes)
                        this.Invoke((MethodInvoker)delegate { RefreshClass(); });
                }
                finally { this.filewatcher.EnableRaisingEvents = true; }
            }
        }

        private void numericUpDownMinChars_ValueChanged(object sender, EventArgs e)
        {
            this.charsneeded = Convert.ToInt32(this.numericUpDownMinChars.Value);
            Properties.Settings.Default.CharsNeeded = this.charsneeded;
            Properties.Settings.Default.Save();
        }
    }
}
