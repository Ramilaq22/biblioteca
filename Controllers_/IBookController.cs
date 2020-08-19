using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public interface IBookController
    {
        Book AddBook(Book book);
        Book CheckBook(int bookISBN);
        Book GetByID(int bookID);
        List<Book> GetNoLoaned(List<Loan> loanList);
        List<Book> GetAll();
    }
}
