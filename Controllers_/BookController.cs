using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public class BookController : IBookController
    {
        BookRepository bookRepository = new BookRepository();
        public Book AddBook(Book book)
        {            
            try
            {
                foreach (Book aux in bookRepository.GetAll())
                {
                    if (book.BookID == aux.BookID)
                    {
                        return null;
                    }
                }

                if (bookRepository.AddBook(book) == null)
                {
                    return null;
                }

                return book;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Book CheckBook(int bookISBN)
        {
            try
            {
                return bookRepository.CheckBook(bookISBN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Book GetByID(int bookID)
        {
            try
            {
                return bookRepository.GetByID(bookID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Book> GetNoLoaned(List<Loan> loanList)
        {
            try 
            { 
                return bookRepository.GetNoLoaned(loanList);
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
                return bookRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
