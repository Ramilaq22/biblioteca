using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public interface IAuthorController
    {
        Author AddAuthor(Author author);
        Author GetByID(int ID);
        List<Author> GetAll();
    }
}
