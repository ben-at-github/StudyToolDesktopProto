namespace StudyTool
{
    partial class EditQuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuestionForm));
            this.treeViewQuestions = new System.Windows.Forms.TreeView();
            this.groupBoxEditor = new System.Windows.Forms.GroupBox();
            this.buttonDiscard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonAddQuestion = new System.Windows.Forms.Button();
            this.buttonAddSection = new System.Windows.Forms.Button();
            this.buttonRemoveData = new System.Windows.Forms.Button();
            this.groupBoxEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewQuestions
            // 
            this.treeViewQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewQuestions.LabelEdit = true;
            this.treeViewQuestions.Location = new System.Drawing.Point(12, 12);
            this.treeViewQuestions.Name = "treeViewQuestions";
            this.treeViewQuestions.Size = new System.Drawing.Size(263, 428);
            this.treeViewQuestions.TabIndex = 0;
            this.treeViewQuestions.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewQuestions_AfterLabelEdit);
            this.treeViewQuestions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewQuestions_NodeMouseClick);
            this.treeViewQuestions.DoubleClick += new System.EventHandler(this.treeViewQuestions_DoubleClick);
            // 
            // groupBoxEditor
            // 
            this.groupBoxEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEditor.Controls.Add(this.buttonDiscard);
            this.groupBoxEditor.Controls.Add(this.label2);
            this.groupBoxEditor.Controls.Add(this.label1);
            this.groupBoxEditor.Controls.Add(this.buttonAccept);
            this.groupBoxEditor.Controls.Add(this.textBoxAnswer);
            this.groupBoxEditor.Controls.Add(this.textBoxQuestion);
            this.groupBoxEditor.Location = new System.Drawing.Point(281, 12);
            this.groupBoxEditor.Name = "groupBoxEditor";
            this.groupBoxEditor.Size = new System.Drawing.Size(374, 210);
            this.groupBoxEditor.TabIndex = 1;
            this.groupBoxEditor.TabStop = false;
            this.groupBoxEditor.Text = "Editor";
            // 
            // buttonDiscard
            // 
            this.buttonDiscard.Location = new System.Drawing.Point(196, 181);
            this.buttonDiscard.Name = "buttonDiscard";
            this.buttonDiscard.Size = new System.Drawing.Size(83, 23);
            this.buttonDiscard.TabIndex = 5;
            this.buttonDiscard.Text = "Discard";
            this.buttonDiscard.UseVisualStyleBackColor = true;
            this.buttonDiscard.Click += new System.EventHandler(this.buttonDiscard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Questions:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(285, 181);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(83, 23);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAnswer.Location = new System.Drawing.Point(69, 96);
            this.textBoxAnswer.Multiline = true;
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(299, 71);
            this.textBoxAnswer.TabIndex = 1;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestion.Location = new System.Drawing.Point(69, 19);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(299, 71);
            this.textBoxQuestion.TabIndex = 0;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(545, 417);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(110, 23);
            this.buttonDone.TabIndex = 2;
            this.buttonDone.Text = "Accept All Changes";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonAddQuestion
            // 
            this.buttonAddQuestion.Location = new System.Drawing.Point(387, 228);
            this.buttonAddQuestion.Name = "buttonAddQuestion";
            this.buttonAddQuestion.Size = new System.Drawing.Size(100, 23);
            this.buttonAddQuestion.TabIndex = 3;
            this.buttonAddQuestion.Text = "Add Question";
            this.buttonAddQuestion.UseVisualStyleBackColor = true;
            this.buttonAddQuestion.Click += new System.EventHandler(this.buttonAddQuestion_Click);
            // 
            // buttonAddSection
            // 
            this.buttonAddSection.Location = new System.Drawing.Point(281, 228);
            this.buttonAddSection.Name = "buttonAddSection";
            this.buttonAddSection.Size = new System.Drawing.Size(100, 23);
            this.buttonAddSection.TabIndex = 4;
            this.buttonAddSection.Text = "Add Section";
            this.buttonAddSection.UseVisualStyleBackColor = true;
            this.buttonAddSection.Click += new System.EventHandler(this.buttonAddSection_Click);
            // 
            // buttonRemoveData
            // 
            this.buttonRemoveData.Location = new System.Drawing.Point(281, 257);
            this.buttonRemoveData.Name = "buttonRemoveData";
            this.buttonRemoveData.Size = new System.Drawing.Size(100, 23);
            this.buttonRemoveData.TabIndex = 6;
            this.buttonRemoveData.Text = "Remove Selected";
            this.buttonRemoveData.UseVisualStyleBackColor = true;
            this.buttonRemoveData.Click += new System.EventHandler(this.buttonRemoveSelected_Click);
            // 
            // EditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 452);
            this.Controls.Add(this.buttonRemoveData);
            this.Controls.Add(this.buttonAddSection);
            this.Controls.Add(this.buttonAddQuestion);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.groupBoxEditor);
            this.Controls.Add(this.treeViewQuestions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditQuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Question Editor";
            this.groupBoxEditor.ResumeLayout(false);
            this.groupBoxEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewQuestions;
        private System.Windows.Forms.GroupBox groupBoxEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonDiscard;
        private System.Windows.Forms.Button buttonAddQuestion;
        private System.Windows.Forms.Button buttonAddSection;
        private System.Windows.Forms.Button buttonRemoveData;
    }
}