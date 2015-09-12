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
    public partial class Loader : Form
    {
        public bool Canceled { get; private set; }

        private struct ClassData
        {
            public string name;
            public string path;
            public override string ToString()
            {
                return name;
            }
        }

        public Class selectedClass { get; private set; }

        private List<ClassData> classes = new List<ClassData>();


        public Loader()
        {
            this.Canceled = true;
            InitializeComponent();
            if (Properties.Settings.Default.Classes == null)
                Properties.Settings.Default.Classes = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.FilePath == null)
                Properties.Settings.Default.FilePath = new System.Collections.Specialized.StringCollection();
            try
            {
                for (int i = 0; i < Properties.Settings.Default.Classes.Count; i++)
                {
                    string cname = Properties.Settings.Default.Classes[i];
                    string path = Properties.Settings.Default.FilePath[i];
                    ClassData cd;
                    cd.name = cname;
                    cd.path = path;
                    this.comboBoxClass.Items.Add(cd);
                    this.classes.Add(cd);

                }
            }
            catch { }
            
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (this.comboBoxClass.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a class", "Select a Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                string path = Properties.Settings.Default.FilePath[this.comboBoxClass.SelectedIndex];
                this.selectedClass = new Class(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Class: " + ex.Message, "Error Loading Class", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Canceled = false;
            this.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateClass cc = new CreateClass();
            cc.ShowDialog();
            string[] splits = cc.filepath.Split('\\');
            string name = splits[splits.Length - 1];
            name = name.Substring(0, name.Length - 4);
            ClassData cd;
            cd.name = name;
            cd.path = cc.filepath;

            Properties.Settings.Default.FilePath.Add(cc.filepath);
            Properties.Settings.Default.Classes.Add(name);
            Properties.Settings.Default.Save();
            this.classes.Add(cd);
            this.comboBoxClass.Items.Add(cd);
            this.comboBoxClass.Refresh();

            Class ctemp = new Class(cd.path);
            ctemp.Save();

            return;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (this.comboBoxClass.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a class", "Select a Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.comboBoxClass.Items.Count > 0)
            {
                Properties.Settings.Default.FilePath.RemoveAt(this.comboBoxClass.SelectedIndex);
                Properties.Settings.Default.Classes.RemoveAt(this.comboBoxClass.SelectedIndex);
                Properties.Settings.Default.Save();

                int idx = this.comboBoxClass.SelectedIndex;
                this.comboBoxClass.Items.RemoveAt(idx);
                this.comboBoxClass.Refresh();
            }
        }
    }
}
