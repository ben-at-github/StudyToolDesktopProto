using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudyToolReader
{

    /// <summary>
    /// Represents a question and answer.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets/Sets the question this StudyToolReader.Question holds.  Default is empty.
        /// </summary>
        public string q { get; set; }

        /// <summary>
        /// Gets/Sets the answer to the question this StudyToolReader.Question holds. Default is empty.
        /// </summary>
        public string a { get; set; }

        /// <summary>
        /// Uniqueidentifier of the Question.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Uniqueidentifier of the set of Questions this Question belongs to.
        /// </summary>
        public Guid QuestionsId { get; set; }

        /// <summary>
        /// Uniqueidentifier of the Class this Question belongs to.
        /// </summary>
        public Guid ClassId { get; set; }

        /// <summary>
        /// Initializes to the default question and answer(emtpy string).
        /// </summary>
        public Question()
        {
            this.q = "";
            this.a = "";
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the StudyToolReader.Question with the given question and answer.
        /// </summary>
        /// <param name="q">The question.</param>
        /// <param name="a">The answer.</param>
        public Question(string q, string a)
        {
            this.q = q;
            this.a = a;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the StudyToolReader.Question with the given System.Xml.XmlNode.
        /// </summary>
        /// <param name="node">System.Xml.XmlNode containing the data to initialize the StudyToolReader.Question with.</param>
        public Question(XmlNode node)
        {
            try
            {
                this.q = node.Attributes["q"].InnerText;
                this.a = node.Attributes["a"].InnerText;
            }
            catch
            {
                this.q = "";
                this.a = "";
            }
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Creates an System.Xml.XmlNode fromt the Question.
        /// </summary>
        /// <param name="xdoc">XmlDocument needed to create the node for.</param>
        /// <returns>Returns the created node.</returns>
        public XmlNode ToXmlNode(XmlDocument xdoc)
        {
            XmlElement node = xdoc.CreateElement("question", null);
            XmlAttribute ques = xdoc.CreateAttribute("q", null);
            ques.InnerText = this.q;
            XmlAttribute ans = xdoc.CreateAttribute("a", null);
            ans.InnerText = this.a;

            node.Attributes.Append(ques);
            node.Attributes.Append(ans);

            return node;
        }
    }
}
