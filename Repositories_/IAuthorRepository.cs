using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Repositories
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);
        Author GetByID(int authorID);
        List<Author> GetAll();
    }
}
