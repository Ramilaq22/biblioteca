using EJ01.Repositories;
using Repositories_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class BookRepository : IBookRepository
    {
        private List<Book> bookList = new List<Book>();
        private IEditorialRepository editorialRepository = new EditorialRepository();
        private IAuthorRepository authorRepository = new AuthorRepository();
        Connection connection = new Connection();

        public BookRepository() { }

        public Book AddBook(Book book)
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Books_Add");
                command.CommandType = CommandType.StoredProcedure;

                var ISBN = command.CreateParameter(); ISBN.ParameterName = "@ISBN"; ISBN.DbType = DbType.Int32; ISBN.Value = book.ISBN; command.Parameters.Add(ISBN);
                var Title = command.CreateParameter(); Title.ParameterName = "@Title"; Title.DbType = DbType.String; Title.Size = 255; Title.Value = book.Title; command.Parameters.Add(Title);
                var EditorialID = command.CreateParameter(); EditorialID.ParameterName = "@EditorialID"; EditorialID.DbType = DbType.Int32; EditorialID.Value = book.Editorial.EditorialID; command.Parameters.Add(EditorialID);
                var Edition = command.CreateParameter(); Edition.ParameterName = "@Edition"; Edition.DbType = DbType.Int32; Edition.Value = book.Edition; command.Parameters.Add(Edition);
                var Year = command.CreateParameter(); Year.ParameterName = "@Year"; Year.DbType = DbType.Int32; Year.Value = book.Year; command.Parameters.Add(Year);
                var EditionYear = command.CreateParameter(); EditionYear.ParameterName = "@EditionYear"; EditionYear.DbType = DbType.Int32; EditionYear.Value = book.EditionYear; command.Parameters.Add(EditionYear);
                var AuthorID = command.CreateParameter(); AuthorID.ParameterName = "@AuthorID"; AuthorID.DbType = DbType.Int32; AuthorID.Value = book.Author.AuthorID; command.Parameters.Add(AuthorID);
                var Deterioration = command.CreateParameter(); Deterioration.ParameterName = "@Deterioration"; Deterioration.DbType = DbType.String; Deterioration.Value = book.Deterioration; command.Parameters.Add(Deterioration);

                var affectedRows = command.ExecuteNonQuery();
                if (affectedRows >= 1) return book;

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

        public Book GetByID(int ID)
        {
            try
            {
                Book book = null;

                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Books_GetByID");
                command.CommandType = CommandType.StoredProcedure;

                var IDParam = command.CreateParameter(); IDParam.ParameterName = "@IDParam"; IDParam.DbType = DbType.Int32; IDParam.Value = ID; command.Parameters.Add(IDParam);
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    int bookID = dr.GetInt32(0);
                    int ISBN = dr.GetInt32(1);
                    Editorial editorial = editorialRepository.GetByID(dr.GetInt32(2));
                    Author author = authorRepository.GetByID(dr.GetInt32(3));
                    string title = dr.GetString(4);
                    int edition = dr.GetInt32(5);
                    int year = dr.GetInt32(6);
                    int editionYear = dr.GetInt32(7);
                    string deterioration = dr.GetString(8);

                    book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                    bookList.Add(book);
                }

                dr.Close();
                return book;
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
            public Book CheckBook(int bookISBN)
            {
                try
                {
                    Book book = null;

                    connection.Connect();

                    var command = connection.CreateCommand();
                    command.CommandText = ("Books_Check");
                    command.CommandType = CommandType.StoredProcedure;

                    var ISBNParam = command.CreateParameter(); ISBNParam.ParameterName = "@ISBNParam"; ISBNParam.DbType = DbType.Int32; ISBNParam.Value = bookISBN; command.Parameters.Add(ISBNParam);
                    var dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        int bookID = dr.GetInt32(0);
                        int ISBN = dr.GetInt32(1);
                        string title = dr.GetString(2);
                        Editorial editorial = editorialRepository.GetByID(dr.GetInt32(3));
                        int edition = dr.GetInt32(4);
                        int year = dr.GetInt32(5);
                        int editionYear = dr.GetInt32(6);
                        Author author = authorRepository.GetByID(dr.GetInt32(7));
                        string deterioration = dr.GetString(8);

                        book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                        bookList.Add(book);
                    }

                    dr.Close();
                    return book;
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
        public List<Book> GetNoLoaned(List<Loan> loanList)
        {
            try
            {
                List<Book> returnList = GetAll();

                foreach (Loan loan in loanList)
                {
                    if (loan.DevolutionDate == default(DateTime))
                    {
                        returnList.Remove(loan.Book);
                    }
                }

                return returnList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Book> GetAll()
        {
            try
            {
                connection.Connect();

                var command = connection.CreateCommand();
                command.CommandText = ("Books_GetAll");
                command.CommandType = CommandType.StoredProcedure;

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int bookID = dr.GetInt32(0);
                    int ISBN = dr.GetInt32(1);
                    string title = dr.GetString(2);
                    Editorial editorial = editorialRepository.GetByID(dr.GetInt32(3));
                    int edition = dr.GetInt32(4);
                    int year = dr.GetInt32(5);
                    int editionYear = dr.GetInt32(6);
                    Author author = authorRepository.GetByID(dr.GetInt32(7));
                    string deterioration = dr.GetString(8);

                    Book book = new Book(bookID, ISBN, title, editorial, edition, year, editionYear, author, deterioration);
                    bookList.Add(book);
                }

                dr.Close();
                return bookList;
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
