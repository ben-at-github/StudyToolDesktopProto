using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;

namespace StudyToolReader
{

    /// <summary>
    /// Organizes and represents StudyToolReader.Questions
    /// </summary>
    public class Class
    {

        /// <summary>
        /// Gets/Sets the name of the class.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Gets/Sets the set of questions this class has.
        /// </summary>
        public List<Questions> questions { get; set; }

        /// <summary>
        /// Where to find the file.
        /// </summary>
        public string filePath { get; set; }

        /// <summary>
        /// Uniqueidentifier of the Class.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes the Class to the default values.
        /// </summary>
        public Class()
        {
            this.name = "";
            this.questions = new List<Questions>();
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the Class with the data from the class node in the XmlDocument.
        /// </summary>
        /// <param name="xdoc">XmlDocument data to be used.</param>
        public Class(XmlDocument xdoc)
        {
            LoadFromNode(GetFirstXmlElement(xdoc));
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes the data with the data from the XmlNode.
        /// </summary>
        /// <param name="node">XmlNode to get data from.</param>
        public Class(XmlNode node)
        {
            LoadFromNode(node);
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes data from the class node from the given document.
        /// </summary>
        /// <param name="filePath">Path to the file where the XmlDocument that has the data is located.</param>
        /// <exception cref="StudyToolReader.MoreThanOneClassInFileException">Thrown when there is an error in the Xml file.  Can be from when there is more than one class node found.</exception>
        public Class(string filePath)
        {
            this.filePath = filePath;
            XmlDocument xdoc = new XmlDocument();
            
            try
            {
                xdoc.Load(filePath);
                LoadFromNode(GetFirstXmlElement(xdoc));
            }
            catch (Exception ex)
            {
                if (ex is XmlException)
                    throw new MoreThanOneClassInFileException(filePath, (XmlException)ex);

                this.name = "";
                this.questions = new List<Questions>();
            }
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Loads the data from the given XmlNode
        /// </summary>
        /// <param name="node">XmlNode to get the data from.</param>
        private void LoadFromNode(XmlNode node)
        {
            this.name = node.Attributes["name"].InnerText;
            this.questions = new List<Questions>();
            foreach (XmlNode n in node.ChildNodes)
            {
                try { this.questions.Add(new Questions(n)); }
                catch { }
            }
        }


        /// <summary>
        /// Creates an System.Xml.XmlNode from the Class
        /// </summary>
        /// <param name="xdoc">XmlDocument needed to create the node for.</param>
        /// <returns>Returns the created node.</returns>
        public XmlNode ToXmlNode(XmlDocument xdoc)
        {
            XmlNode node = xdoc.CreateElement("class", null);
            XmlAttribute n = xdoc.CreateAttribute("name", null);
            n.InnerText = this.name;

            node.Attributes.Append(n);

            foreach (Questions qs in this.questions)
            {
                try { node.AppendChild(qs.ToXmlNode(xdoc)); }
                catch { }
            }

            return node;
        }


        /// <summary>
        /// Creates a System.Xml.XmlDocument from the Class.  Does NOT save it to disk.
        /// </summary>
        /// <returns>Returns the created XmlDocument.</returns>
        public XmlDocument ToXmlDocument()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.AppendChild(xdoc.CreateXmlDeclaration("1.0", "utf-8", null));
            xdoc.AppendChild(this.ToXmlNode(xdoc));

            return xdoc;
        }

        /// <summary>
        /// Careates and saves a XmlDocument from the Class.
        /// </summary>
        /// <param name="filePath">File path where you want to save the file.</param>
        /// <returns>Returns the created XmlDocument.</returns>
        /// <exception cref="StudyToolReader.FailToSaveClassException">Thrown when there is an error saving the class to the file.</exception>
        public XmlDocument CreateXmlDocument(string filePath)
        {
            XmlDocument xdoc;

            try
            {
                this.filePath = filePath;
                xdoc = this.ToXmlDocument();
                XmlWriter writter = XmlWriter.Create(filePath, new XmlWriterSettings { NewLineOnAttributes = false, NewLineHandling = NewLineHandling.Replace, Indent = true, NewLineChars = "\n", Encoding = Encoding.UTF8, IndentChars = "\t" });
                xdoc.WriteTo(writter);
                writter.Flush();
                writter.Close();
            }
            catch { throw new FailToSaveClassException(filePath); }

            return xdoc;
        }

        /// <summary>
        /// Gets the first XmlElement from the document.
        /// </summary>
        /// <param name="xdoc">The xml document you want to use.</param>
        /// <returns>Returns the first found xml element from the document.</returns>
        private static XmlNode GetFirstXmlElement(XmlDocument xdoc)
        {
            XmlNode node = null;

            foreach(XmlNode n in xdoc.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element)
                {
                    node = n;
                    break;
                }
            }

            return node;
        }

        /// <summary>
        /// Saves the Class to the file specified from the filePath field.
        /// </summary>
        public void Save()
        {
            this.CreateXmlDocument(this.filePath);
        }

        /// <summary>
        /// Saves the Class to the inputed file.
        /// </summary>
        /// <param name="filePath">Filepath where to save the file.</param>
        public void Save(string filePath)
        {
            this.CreateXmlDocument(filePath);
        }

    }

    /// <summary>
    /// Class defining an exception that occurs while trying to save a class and it fails.
    /// </summary>
    public class FailToSaveClassException : Exception
    {
        public FailToSaveClassException() : base() { }

        public FailToSaveClassException(string filename) : base("Failed to save Class to file '" + filename + "'") { }
    }

    /// <summary>
    /// Class defining an exception that occurs while trying to load a class with more than one class node.
    /// </summary>
    public class MoreThanOneClassInFileException : Exception
    {
        public MoreThanOneClassInFileException() : base() { }

        public MoreThanOneClassInFileException(string filename) : base("More than one class in the file '" + filename + "'") { }

        public MoreThanOneClassInFileException(string filename, XmlException ex) : base("More than one class in the file '" + filename + "'.  " + ex.Message) { }

        public MoreThanOneClassInFileException(string filename, string msg) : base("More than one class in the file '" + filename + "'.  " + msg) { }
    }
}
