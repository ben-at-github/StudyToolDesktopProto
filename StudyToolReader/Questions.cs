using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudyToolReader
{

    /// <summary>
    /// Represents a set of questions and answers
    /// </summary>
    public class Questions
    {

        /// <summary>
        /// Gets/Sets the name of the section.  Used for organizing sets of StudyToolReader.Questions.
        /// </summary>
        public string section { get; set; }

        /// <summary>
        /// Gets/Sets the list of questions.
        /// </summary>
        public List<Question> questions { get; set; }

        /// <summary>
        /// Uniqueidentifier of the set of Questions.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Uniqueidentifier of the Class this set of Questions belongs to.
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Initializes the set of questions to their default values.
        /// </summary>
        public Questions()
        {
            this.section = "";
            this.questions = new List<Question>();
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the set of questions with the data from the System.Xml.XmlNode.
        /// </summary>
        /// <param name="node">XmlNode Containing the data.</param>
        public Questions(XmlNode node)
        {
            try { this.section = node.Attributes["section"].InnerText; }
            catch { this.section = ""; }

            this.questions = new List<Question>();
            foreach(XmlNode q in node.ChildNodes)
            {
                try { this.questions.Add(new Question(q)); }
                catch { }
            }
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the set of questions with the given set of questions and section.
        /// </summary>
        /// <param name="questions">List of questions.</param>
        /// <param name="section">Name of the section.</param>
        public Questions(List<Question> questions, string section)
        {
            this.questions = questions;
            this.section = section;
            this.Id = Guid.NewGuid();
        }


        /// <summary>
        /// Creates an System.Xml.XmlNode from the Questions
        /// </summary>
        /// <param name="xdoc">XmlDocument needed to create the node for.</param>
        /// <returns>Returns the created node.</returns>
        public XmlNode ToXmlNode(XmlDocument xdoc)
        {
            XmlNode node = xdoc.CreateElement("questions", null);
            XmlAttribute s = xdoc.CreateAttribute("section", null);
            s.InnerText = this.section;

            node.Attributes.Append(s);

            foreach (Question q in this.questions)
            {
                try { node.AppendChild(q.ToXmlNode(xdoc)); }
                catch { }
            }

            return node;
        }
    }
}
