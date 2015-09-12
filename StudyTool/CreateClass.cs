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
    public partial class CreateClass : Form
    {

        public string filepath { get; private set; }

        public CreateClass()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (openFileDialogImport.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.filepath = openFileDialogImport.FileName;
                    Class c = new Class(this.filepath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error While Importing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;

            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            bool missingData = false;
            string msg = "";
            if (String.IsNullOrWhiteSpace(this.textBoxName.Text))
            {
                missingData = true;
                msg += "A name is required.\n";
            }
            if (String.IsNullOrWhiteSpace(this.textBoxFolder.Text))
            {
                missingData = true;
                msg += "A folder path is required.\n";
            }
            if (missingData)
            {
                MessageBox.Show(msg, "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.filepath = this.textBoxFolder.Text + "\\" + this.textBoxName.Text + ".xml";

            this.Close();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialogSelectFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBoxFolder.Text = folderBrowserDialogSelectFolder.SelectedPath;

        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
