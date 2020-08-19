using EJ01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public class AuthorController : IAuthorController
    {
        AuthorRepository authorRepository = new AuthorRepository();
        public Author AddAuthor(Author author)
        {
            try
            {
                foreach (Author aux in authorRepository.GetAll())
                {
                    if (author.Name == aux.Name)
                    {
                        return null;
                    }
                }

                if (authorRepository.AddAuthor(author) == null)
                {
                    return null;
                }

                return author;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Author GetByID(int authorID)
        {
            try
            {
                return authorRepository.GetByID(authorID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Author> GetAll()
        {
            try
            {
                return authorRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
