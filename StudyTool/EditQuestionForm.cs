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
    public partial class EditQuestionForm : Form
    {
        private enum NodeType { Question, Section, Class }

        private int cachedSectionIndex;
        private int cachedQuestionIndex;
        public Class c { get; private set; }

        public bool Canceled { get; private set; }

        private NodeType lastSelectedNodeType { get; set; }

        public EditQuestionForm(Class c)
        {
            InitializeComponent();

            this.Canceled = true;
            this.c = c;

            this.treeViewQuestions.Nodes.Add(ClassToTreeNode(this.c));
            this.treeViewQuestions.ExpandAll();

            this.groupBoxEditor.Enabled = false;
            this.buttonAddQuestion.Enabled = false;
        }


        private void treeViewQuestions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.groupBoxEditor.Enabled = false;

            if (NodeHasParent(e.Node))
            {
                if (e.Node.Parent.Text != this.c.name)//on question
                {
                    this.cachedQuestionIndex = e.Node.Index;
                    this.cachedSectionIndex = e.Node.Parent.Index;
                    this.lastSelectedNodeType = NodeType.Question;

                    this.textBoxQuestion.Text = this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].q;
                    this.textBoxAnswer.Text = this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].a;
                    this.groupBoxEditor.Enabled = true;
                    this.buttonAddQuestion.Enabled = true;
                }
                else//on section
                {
                    this.cachedSectionIndex = e.Node.Index;
                    this.lastSelectedNodeType = NodeType.Section;

                    this.buttonAddQuestion.Enabled = true;
                    this.textBoxQuestion.ResetText();
                    this.textBoxAnswer.ResetText();
                }
            }
            else//on class
            {
                this.lastSelectedNodeType = NodeType.Class;

                this.buttonAddQuestion.Enabled = false;
                this.textBoxQuestion.ResetText();
                this.textBoxAnswer.ResetText();
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].q = this.textBoxQuestion.Text;
            this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].a = this.textBoxAnswer.Text;
            this.treeViewQuestions.Nodes[0].Nodes[this.cachedSectionIndex].Nodes[this.cachedQuestionIndex].Text = this.textBoxQuestion.Text;
        }
        
        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.c.Save();
            this.Canceled = false;
            this.Close();
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            this.textBoxQuestion.Text = this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].q;
            this.textBoxAnswer.Text = this.c.questions[this.cachedSectionIndex].questions[this.cachedQuestionIndex].a;
        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            if (this.lastSelectedNodeType == NodeType.Class)
                return;

            NewQuestionForm nqf = new NewQuestionForm();
            nqf.ShowDialog(this);

            if (nqf.Canceled)
                return;

            this.c.questions[this.cachedSectionIndex].questions.Add(nqf.Question);
            TreeNode node = this.treeViewQuestions.Nodes[0].Nodes[this.cachedSectionIndex].Nodes.Add(nqf.Question.q);
            node.Parent.Expand();
            this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(node, System.Windows.Forms.MouseButtons.Left, 1, 0, 0));
            
        }

        private void buttonAddSection_Click(object sender, EventArgs e)
        {
            NewSectionForm nsf = new NewSectionForm();
            nsf.ShowDialog(this);

            if (nsf.Canceled)
                return;

            this.c.questions.Add(nsf.questions);
            TreeNode node = SectionToTreeNode(nsf.questions);
            this.treeViewQuestions.Nodes[0].Nodes.Add(node);
            node.Expand();
            this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(node, System.Windows.Forms.MouseButtons.Left, 1, 0, 0));

        }

        private static bool NodeHasParent(TreeNode node)
        {
            try
            {
                if (node.Parent != null)
                    return true;
            }
            catch { }
            
            return false;
        }

        private static TreeNode QuestionToTreeNode(Question q)
        {
            return new TreeNode(q.q);
        }

        private static TreeNode SectionToTreeNode(Questions qs)
        {
            TreeNode node = new TreeNode(qs.section);
            foreach (Question q in qs.questions)
                node.Nodes.Add(QuestionToTreeNode(q));

            return node;
        }

        private static TreeNode ClassToTreeNode(Class cl)
        {
            TreeNode node = new TreeNode(cl.name);
            foreach (Questions qs in cl.questions)
                node.Nodes.Add(SectionToTreeNode(qs));

            return node;
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            switch(this.lastSelectedNodeType)
            {
                case NodeType.Question:
                    this.c.questions[this.cachedSectionIndex].questions.RemoveAt(this.cachedQuestionIndex);
                    this.treeViewQuestions.Nodes[0].Nodes[this.cachedSectionIndex].Nodes.RemoveAt(this.cachedQuestionIndex);
                    this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(this.treeViewQuestions.Nodes[0].Nodes[this.cachedSectionIndex], System.Windows.Forms.MouseButtons.Left, 1, 0, 0));
                    return;
                case NodeType.Section:
                    this.c.questions.RemoveAt(this.cachedSectionIndex);
                    this.treeViewQuestions.Nodes[0].Nodes.RemoveAt(this.cachedSectionIndex);
                    this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(this.treeViewQuestions.Nodes[0], System.Windows.Forms.MouseButtons.Left, 1, 0, 0));
                    return;
                case NodeType.Class:
                    this.c.questions = new List<Questions>();
                    this.treeViewQuestions.Nodes[0].Nodes.Clear();
                    this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(this.treeViewQuestions.Nodes[0], System.Windows.Forms.MouseButtons.Left, 1, 0, 0));
                    return;
                default:
                    return;
            }
        }

        private void treeViewQuestions_DoubleClick(object sender, EventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = tv.SelectedNode;
            
            this.lastSelectedNodeType = this.GetNodeType(node);
            switch (this.lastSelectedNodeType)
            {
                case NodeType.Question:
                    this.treeViewQuestions_NodeMouseClick(this.treeViewQuestions, new TreeNodeMouseClickEventArgs(node, System.Windows.Forms.MouseButtons.Left, 1, 0, 0));
                    return;
                case NodeType.Section:
                    this.cachedQuestionIndex = node.Index;
                    node.BeginEdit();
                    return;
                case NodeType.Class:
                    node.BeginEdit();
                    return;
                default:
                    return;
            }
        }

        private NodeType GetNodeType(TreeNode node)
        {
            if (NodeHasParent(node))
            {
                if (node.Parent.Text == this.c.name)
                    return NodeType.Section;
                return NodeType.Question;
            }
            else
                return NodeType.Class;
        }

        private void treeViewQuestions_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            TreeNode node = tv.SelectedNode;
            
            switch(this.lastSelectedNodeType)
            {
                case NodeType.Question:
                    return;
                case NodeType.Section:
                    this.c.questions[this.cachedSectionIndex].section = e.Label;
                    return;
                case NodeType.Class:
                    this.c.name = e.Label;
                    return;
                default:
                    return;
            }
        }
        
    }
}
