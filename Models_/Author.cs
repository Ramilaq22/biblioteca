using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Author
    {
        public Author(int authorID, string name)
        {
            AuthorID = authorID;
            Name = name;
        }
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }
}
