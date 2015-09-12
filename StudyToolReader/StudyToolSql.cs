using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudyToolReader
{
    /// <summary>
    /// Querys the database for Class, Questions, and Question objects.
    /// Uses connection string found in the App.config connectionstring with the name 'StudyToolDB'.
    /// </summary>
    public static class StudyToolSql
    {
        private static string connString
        { 
            get
            {
                try { return System.Configuration.ConfigurationManager.ConnectionStrings["StudyToolDB"].ConnectionString; }
                catch (Exception ex) { throw new Exception("Error fetching the required connection string.  Make sure a connection string exists in the App.config file with name 'StudyToolDB' and that the proper databases were created.", ex); }
            }
        }

        #region Gets

        /// <summary>
        /// Gets all of the Class objects from the database.
        /// </summary>
        /// <param name="omitQuestionSets">Wether you want to get the Questions object sets or not.</param>
        /// <param name="omitQuestions">Wether you want to get the Question objects or not.</param>
        /// <returns>List of Class objects found in the database.</returns>
        public static List<Class> GetClasses(bool omitQuestionSets = false, bool omitQuestions = false)
        {
            List<Class> classes = new List<Class>();
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Class;";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    classes.Add(new Class()
                    {
                        Id = reader.GetGuid(0),
                        name = reader.GetString(1),
                    });
                }
                reader.Close();
                conn.Close();
            }

            if (!omitQuestionSets)
                classes.ForEach(c => c.questions = StudyToolSql.GetQuestionSets(c.Id, omitQuestions));

            return classes;
        }

        /// <summary>
        /// Gets the Class object from the database matching the given id.
        /// </summary>
        /// <param name="id">Id of the Class you want to find.</param>
        /// <param name="omitQuestionSets">Wether you want to get the Questions object sets or not.</param>
        /// <param name="omitQuestions">Wether you want to get the Question objects or not.</param>
        /// <returns>Class object found in the database.</returns>
        public static Class GetClass(Guid id, bool omitQuestionSets = false, bool omitQuestions = false)
        {
            Class c;
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Class where Id = '" + id.ToString() + "';";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                c = new Class()
                {
                    Id = reader.GetGuid(0),
                    name = reader.GetString(1),
                };
                reader.Close();
                conn.Close();
            }

            if (!omitQuestionSets)
                c.questions = StudyToolSql.GetQuestionSets(c.Id, omitQuestions);

            return c;
        }

        /// <summary>
        /// Gets the set of Question from the given Class objects Id.
        /// </summary>
        /// <param name="classId">Id of the Class you wans to get the Questions for.</param>
        /// <param name="omitQuestions">Wether you want to get the Question objects or not.</param>
        /// <returns>List of Questions found in the database.</returns>
        public static List<Questions> GetQuestionSets(Guid classId, bool omitQuestions = false)
        {
            List<Questions> questions = new List<Questions>();
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Questions where ClassId = '" + classId.ToString() + "';";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    questions.Add(new Questions()
                    {
                        Id = reader.GetGuid(0),
                        ClassId = reader.GetGuid(1),
                        section = reader.GetString(2),
                    });
                }
                reader.Close();
                conn.Close();
            }

            if (!omitQuestions)
                questions.ForEach(q => q.questions = StudyToolSql.GetQuestions(q.Id, classId));

            return questions;
        }

        /// <summary>
        /// Gets the Questions set from the given Ids.
        /// </summary>
        /// <param name="id">Id of the Questions set to find.</param>
        /// <param name="classId">Id of the parent Class.</param>
        /// <param name="omitQuestions">Whether you want to get the Question objects or not.</param>
        /// <returns>The Questions set from the database.</returns>
        public static Questions GetQuestionSet(Guid id, Guid classId, bool omitQuestions = false)
        {
            Questions q;
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Questions where Id = '" + id.ToString() + "' and ClassId = '" + classId.ToString() + "';";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                q = new Questions()
                {
                    Id = reader.GetGuid(0),
                    ClassId = reader.GetGuid(1),
                    section = reader.GetString(2),
                };
                reader.Close();
                conn.Close();
            }

            if (!omitQuestions)
                q.questions = StudyToolSql.GetQuestions(q.Id, classId);


            return q;
        }
        
        /// <summary>
        /// Gets all the Question objects from the database from given parent Questions id and Class id.
        /// </summary>
        /// <param name="setId">Id of the parent Questions set.</param>
        /// <param name="classId">Id of the parent Class.</param>
        /// <returns>List of Question objects from the database.</returns>
        public static List<Question> GetQuestions(Guid setId, Guid classId)
        {
            List<Question> questions = new List<Question>();
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Question where QuestionsId = '" + setId.ToString() + "' and ClassId = '" + classId.ToString() + "';";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    questions.Add(new Question()
                    {
                        Id = reader.GetGuid(0),
                        QuestionsId = reader.GetGuid(1),
                        ClassId = reader.GetGuid(2),
                        q = reader.GetString(3),
                        a = reader.GetString(4),
                    });
                }
                reader.Close();
                conn.Close();
            }

            return questions;
        }

        /// <summary>
        /// Gets Question objects from the database from given ids.
        /// </summary>
        /// <param name="id">Id of the Question.</param>
        /// <param name="setId">Id of the parent Questions set.</param>
        /// <param name="classId">Id of the parent Class.</param>
        /// <returns>Question object from the database.</returns>
        public static Question GetQuestion(Guid id, Guid setId, Guid classId)
        {
            Question question;
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                string text = "select * from dbo.Question where Id = '" + id.ToString() + "' and QuestionsId = '" + setId.ToString() + "' and ClassId = '" + classId.ToString() + "';";
                SqlCommand cmd = new SqlCommand(text, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                question = new Question()
                {
                    Id = reader.GetGuid(0),
                    QuestionsId = reader.GetGuid(1),
                    ClassId = reader.GetGuid(2),
                    q = reader.GetString(3),
                    a = reader.GetString(4),
                };
                reader.Close();
                conn.Close();
            }

            return question;
        }

        #endregion

        #region Adds

        /// <summary>
        /// Adds the Class to the database.
        /// </summary>
        /// <param name="c">The Class you want to add.</param>
        /// <param name="omitQuestionSets">Whether you want to add the Questions sets too.</param>
        /// <param name="omitQuestions">Whether you want to add the Question objects too.</param>
        public static void AddClass(Class c, bool omitQuestionSets = false, bool omitQuestions = false)
        {
            string text = "insert into dbo.Class values ('" + c.Id + "', '" + c.name + "');";
            StudyToolSql.RunSql(text);

            if (!omitQuestionSets)
                c.questions.ForEach(qs => StudyToolSql.AddQuestionSet(qs, c.Id, omitQuestions));

        }

        /// <summary>
        /// Adds the Questions set to the database.
        /// </summary>
        /// <param name="questions">The Questions set you want to add.</param>
        /// <param name="classId">The id of the parent Class.</param>
        /// <param name="omitQuestions">Whether you want to add Question objects too.</param>
        public static void AddQuestionSet(Questions questions, Guid classId, bool omitQuestions = false)
        {
            string text = "insert into dbo.Questions values ('" + questions.Id.ToString() + "', '" + classId.ToString() + "', '" + questions.section + "');";
            StudyToolSql.RunSql(text);

            if (!omitQuestions)
                questions.questions.ForEach(q => StudyToolSql.AddQuestion(q, questions.Id, classId));
        }

        /// <summary>
        /// Adds the Question to the database.
        /// </summary>
        /// <param name="question">The Question you want to add.</param>
        /// <param name="setId">The id of the parent Questions set.</param>
        /// <param name="classId">The id of the parent Class.</param>
        public static void AddQuestion(Question question, Guid setId, Guid classId)
        {
            string text = "insert into dbo.Question values ('" + question.Id.ToString() + "', '" + setId.ToString() + "', '" + classId + "', '" + question.q.Replace("'", "") + "', '" + question.a.Replace("'", "") + "');";
            StudyToolSql.RunSql(text);
        }

        #endregion

        #region Updates

        /// <summary>
        /// Updates the Class in the database.
        /// </summary>
        /// <param name="c">The Class you want to update.</param>
        /// <param name="omitQuestionSets">Whether you want to update the Questions sets too.</param>
        /// <param name="omitQuestions">Whether you want to update the Question objects too.</param>
        public static void UpdateClass(Class c, bool omitQuestionSets = false, bool omitQuestions = false)
        {
            string text = "update dbo.Class set name = '" + c.name + "' where Id = '" + c.Id.ToString() + "';";
            StudyToolSql.RunSql(text);

            if (!omitQuestionSets)
                c.questions.ForEach(qs => StudyToolSql.UpdateQuestionSet(qs, c.Id, omitQuestions));
        }

        /// <summary>
        /// Updates the Questions set in the database.
        /// </summary>
        /// <param name="questions">The Questions set you want to update.</param>
        /// <param name="classId">The id of the parent Class.</param>
        /// <param name="omitQuestions">Whether you want to update Question objects too.</param>
        public static void UpdateQuestionSet(Questions questions, Guid classId, bool omitQuestions = false)
        {
            string text = "update dbo.Questions set section = '" + questions.section + "' where Id = '" + questions.Id.ToString() + "' and ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);

            if (!omitQuestions)
                questions.questions.ForEach(q => StudyToolSql.UpdateQuestion(q, questions.Id, classId));
        }

        /// <summary>
        /// Updates the Question in the database.
        /// </summary>
        /// <param name="question">The Question you want to update.</param>
        /// <param name="setId">The id of the parent Questions set.</param>
        /// <param name="classId">The id of the parent Class.</param>
        public static void UpdateQuestion(Question question, Guid setId, Guid classId)
        {
            string text = "update dbo.Question set q = '" + question.q.Replace("'", "") + "', a = '" + question.a.Replace("'", "") + "' where Id = '" + question.Id.ToString() + "' and QuestionsId = '" + setId.ToString() + "' and ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
        }

        #endregion

        #region Deletes

        /// <summary>
        /// Nukes the database. :(
        /// </summary>
        public static void Nuke()
        {
            string text = "delete from dbo.Class; delete from dbo.Questions; delete from dbo.Question;";
            StudyToolSql.RunSql(text);
        }

        /// <summary>
        /// Deletes the Class from the database.
        /// </summary>
        /// <param name="id">Id of the class you want to delete.</param>
        /// <param name="omitQuestionSets">Whether you want to keep the Questions sets or not.</param>
        /// <param name="omitQuestions">Wether you want to keep the Question objects or not.</param>
        public static void DeleteClass(Guid id, bool omitQuestionSets = false, bool omitQuestions = false)
        {
            string text = "delete from dbo.Class where Id = '" + id.ToString() + "';";
            StudyToolSql.RunSql(text);
            if (!omitQuestionSets)
                StudyToolSql.DeleteQuestionSets(id, omitQuestions);

        }

        /// <summary>
        /// Deletes the Questions sets from the database of the given Class.
        /// </summary>
        /// <param name="classId">Id of the parent Class.</param>
        /// <param name="omitQuestions">Wether you want to keep the Question objects or not.</param>
        public static void DeleteQuestionSets(Guid classId, bool omitQuestions = false)
        {
            string text = "delete from dbo.Questions where ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
            if (!omitQuestions)
                StudyToolSql.DeleteQuestions(classId);
        }

        /// <summary>
        /// Deletes the Questions set from the database.
        /// </summary>
        /// <param name="id">Id of the Questions set you want to delete.</param>
        /// <param name="classId">Id of the parent Class.</param>
        /// <param name="omitQuestions">Wether you want to keep the Question objects or not.</param>
        public static void DeleteQuestionSet(Guid id, Guid classId, bool omitQuestions = false)
        {
            string text = "delete from dbo.Questions where Id = '" + id.ToString() + "' and ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
            if (!omitQuestions)
                StudyToolSql.DeleteQuestions(id, classId);
        }

        /// <summary>
        /// Deletes the Question objects from the database of the given Class.
        /// </summary>
        /// <param name="classId">Id of the Class.</param>
        public static void DeleteQuestions(Guid classId)
        {
            string text = "delete from dbo.Question where ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
        }

        /// <summary>
        /// Deletes the Question objects from the database of the given Questions set.
        /// </summary>
        /// <param name="setId">Id of the Questions set.</param>
        /// <param name="classId">Id of the parent Class.</param>
        public static void DeleteQuestions(Guid setId, Guid classId)
        {
            string text = "delete from dbo.Question where QuestionsId = '" + setId.ToString() + "' and ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
        }

        /// <summary>
        /// Deletes the Question object from the database.
        /// </summary>
        /// <param name="id">Id of the Question object.</param>
        /// <param name="setId">Id of the Questions set it's in.</param>
        /// <param name="classId">Id of the parent Class.</param>
        public static void DeleteQuestion(Guid id, Guid setId, Guid classId)
        {
            string text = "delete from dbo.Question where Id = '" + id.ToString()  + "' and QuestionsId = '" + setId.ToString() + "' and ClassId = '" + classId.ToString() + "';";
            StudyToolSql.RunSql(text);
        }


        #endregion

        #region Utilities

        /// <summary>
        /// Performs an ExecuteNonQuery() on the given Sql code.
        /// </summary>
        /// <param name="statement">Sql code to run.</param>
        private static void RunSql(string statement)
        {
            using (SqlConnection conn = new SqlConnection(StudyToolSql.connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(statement, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        #endregion
    }
}