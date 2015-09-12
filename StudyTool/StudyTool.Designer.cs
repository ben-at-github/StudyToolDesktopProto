namespace StudyTool
{
    partial class StudyTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudyTool));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.checkBoxHighlight = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMinChars = new System.Windows.Forms.NumericUpDown();
            this.checkedListBoxSections = new System.Windows.Forms.CheckedListBox();
            this.buttonEditQuestion = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.richTextBoxAnswers = new System.Windows.Forms.RichTextBox();
            this.buttonViewQuestions = new System.Windows.Forms.Button();
            this.buttonViewClass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadNewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNewClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinChars)).BeginInit();
            this.groupBoxData.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sections";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxActions.Controls.Add(this.checkBoxHighlight);
            this.groupBoxActions.Controls.Add(this.label3);
            this.groupBoxActions.Controls.Add(this.numericUpDownMinChars);
            this.groupBoxActions.Controls.Add(this.checkedListBoxSections);
            this.groupBoxActions.Controls.Add(this.buttonEditQuestion);
            this.groupBoxActions.Controls.Add(this.label1);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 472);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(378, 160);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // checkBoxHighlight
            // 
            this.checkBoxHighlight.AutoSize = true;
            this.checkBoxHighlight.Checked = true;
            this.checkBoxHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHighlight.Location = new System.Drawing.Point(251, 69);
            this.checkBoxHighlight.Name = "checkBoxHighlight";
            this.checkBoxHighlight.Size = new System.Drawing.Size(67, 17);
            this.checkBoxHighlight.TabIndex = 8;
            this.checkBoxHighlight.Text = "Highlight";
            this.checkBoxHighlight.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Characters";
            // 
            // numericUpDownMinChars
            // 
            this.numericUpDownMinChars.Location = new System.Drawing.Point(251, 105);
            this.numericUpDownMinChars.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMinChars.Name = "numericUpDownMinChars";
            this.numericUpDownMinChars.Size = new System.Drawing.Size(121, 20);
            this.numericUpDownMinChars.TabIndex = 6;
            this.numericUpDownMinChars.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownMinChars.ValueChanged += new System.EventHandler(this.numericUpDownMinChars_ValueChanged);
            // 
            // checkedListBoxSections
            // 
            this.checkedListBoxSections.FormattingEnabled = true;
            this.checkedListBoxSections.Location = new System.Drawing.Point(60, 19);
            this.checkedListBoxSections.Name = "checkedListBoxSections";
            this.checkedListBoxSections.Size = new System.Drawing.Size(185, 139);
            this.checkedListBoxSections.TabIndex = 5;
            this.checkedListBoxSections.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxSections_ItemCheck);
            // 
            // buttonEditQuestion
            // 
            this.buttonEditQuestion.Location = new System.Drawing.Point(251, 131);
            this.buttonEditQuestion.Name = "buttonEditQuestion";
            this.buttonEditQuestion.Size = new System.Drawing.Size(121, 23);
            this.buttonEditQuestion.TabIndex = 4;
            this.buttonEditQuestion.Text = "Open Question Editor";
            this.buttonEditQuestion.UseVisualStyleBackColor = true;
            this.buttonEditQuestion.Click += new System.EventHandler(this.buttonEditQuestion_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxData.Controls.Add(this.richTextBoxAnswers);
            this.groupBoxData.Controls.Add(this.buttonViewQuestions);
            this.groupBoxData.Controls.Add(this.buttonViewClass);
            this.groupBoxData.Controls.Add(this.label2);
            this.groupBoxData.Controls.Add(this.textBoxQuestion);
            this.groupBoxData.Location = new System.Drawing.Point(13, 28);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(875, 438);
            this.groupBoxData.TabIndex = 3;
            this.groupBoxData.TabStop = false;
            // 
            // richTextBoxAnswers
            // 
            this.richTextBoxAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAnswers.BackColor = System.Drawing.Color.Black;
            this.richTextBoxAnswers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxAnswers.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAnswers.ForeColor = System.Drawing.Color.White;
            this.richTextBoxAnswers.Location = new System.Drawing.Point(9, 80);
            this.richTextBoxAnswers.Name = "richTextBoxAnswers";
            this.richTextBoxAnswers.ReadOnly = true;
            this.richTextBoxAnswers.Size = new System.Drawing.Size(860, 352);
            this.richTextBoxAnswers.TabIndex = 8;
            this.richTextBoxAnswers.Text = "";
            // 
            // buttonViewQuestions
            // 
            this.buttonViewQuestions.Location = new System.Drawing.Point(9, 51);
            this.buttonViewQuestions.Name = "buttonViewQuestions";
            this.buttonViewQuestions.Size = new System.Drawing.Size(112, 23);
            this.buttonViewQuestions.TabIndex = 6;
            this.buttonViewQuestions.Text = "View Questions";
            this.buttonViewQuestions.UseVisualStyleBackColor = true;
            this.buttonViewQuestions.Click += new System.EventHandler(this.buttonViewQuestions_Click);
            // 
            // buttonViewClass
            // 
            this.buttonViewClass.Location = new System.Drawing.Point(127, 51);
            this.buttonViewClass.Name = "buttonViewClass";
            this.buttonViewClass.Size = new System.Drawing.Size(112, 23);
            this.buttonViewClass.TabIndex = 7;
            this.buttonViewClass.Text = "View All Questions";
            this.buttonViewClass.UseVisualStyleBackColor = true;
            this.buttonViewClass.Click += new System.EventHandler(this.buttonViewClass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ask a question";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuestion.Location = new System.Drawing.Point(89, 19);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(780, 26);
            this.textBoxQuestion.TabIndex = 0;
            this.textBoxQuestion.TextChanged += new System.EventHandler(this.textBoxQuestion_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonOptions
            // 
            this.toolStripDropDownButtonOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadNewProfileToolStripMenuItem,
            this.reloadClassToolStripMenuItem});
            this.toolStripDropDownButtonOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonOptions.Image")));
            this.toolStripDropDownButtonOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonOptions.Name = "toolStripDropDownButtonOptions";
            this.toolStripDropDownButtonOptions.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonOptions.Text = "Options";
            // 
            // loadNewProfileToolStripMenuItem
            // 
            this.loadNewProfileToolStripMenuItem.Name = "loadNewProfileToolStripMenuItem";
            this.loadNewProfileToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadNewProfileToolStripMenuItem.Text = "Load New Class";
            this.loadNewProfileToolStripMenuItem.Click += new System.EventHandler(this.loadNewProfileToolStripMenuItem_Click);
            // 
            // reloadClassToolStripMenuItem
            // 
            this.reloadClassToolStripMenuItem.Name = "reloadClassToolStripMenuItem";
            this.reloadClassToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.reloadClassToolStripMenuItem.Text = "Reload Class";
            this.reloadClassToolStripMenuItem.Click += new System.EventHandler(this.reloadClassToolStripMenuItem_Click);
            // 
            // loadNewClassToolStripMenuItem
            // 
            this.loadNewClassToolStripMenuItem.Name = "loadNewClassToolStripMenuItem";
            this.loadNewClassToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loadNewClassToolStripMenuItem.Text = "Load New Class";
            // 
            // StudyTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 644);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBoxActions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudyTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Study Tool";
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinChars)).EndInit();
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxData.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Button buttonEditQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button buttonViewQuestions;
        private System.Windows.Forms.Button buttonViewClass;
        private System.Windows.Forms.RichTextBox richTextBoxAnswers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadNewClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonOptions;
        private System.Windows.Forms.ToolStripMenuItem loadNewProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadClassToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBoxSections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMinChars;
        private System.Windows.Forms.CheckBox checkBoxHighlight;
    }
}