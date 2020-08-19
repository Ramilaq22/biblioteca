using Repositories_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> authorList = new List<Author>();
        Connection connection = new Connection();
        public AuthorRepository() { }

        public Author AddAuthor(Author author)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Authors_Add");
                command.CommandType = CommandType.StoredProcedure;

                var Name = command.CreateParameter(); Name.ParameterName = "@Name"; Name.DbType = DbType.String; Name.Size = 255; Name.Value = author.Name; command.Parameters.Add(Name);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return author;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Disconnect();
            }
        }

        public Author GetByID(int ID)
        {
            try
            {
                Author author = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Authors_GetByID");
                command.CommandType = CommandType.StoredProcedure;

                var AuthorIDParam = command.CreateParameter(); AuthorIDParam.ParameterName = "@AuthorIDParam"; AuthorIDParam.DbType = DbType.Int32; AuthorIDParam.Value = ID; command.Parameters.Add(AuthorIDParam);
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int authorID = dr.GetInt32(0);
                    string name = dr.GetString(1);

                    author = new Author(authorID, name);
                    authorList.Add(author);
                }

                dr.Close();
                return author;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Disconnect();
            }
        }

        public List<Author> GetAll()
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Authors_GetAll");
                command.CommandType = CommandType.StoredProcedure;

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int authorID = dr.GetInt32(0);
                    string name = dr.GetString(1);

                    Author author = new Author(authorID, name);
                    authorList.Add(author);
                }

                dr.Close();
                return authorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Disconnect();
            }
        }
    }
}
