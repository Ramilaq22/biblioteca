using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Book
    {        
        public Book(int bookID, int ISBN, string title, Editorial editorial, int edition, int year, int editionYear, Author author, string deterioration)
        {
            BookID = bookID;
            this.ISBN = ISBN;
            Title = title;
            Editorial = editorial;
            Edition = edition;
            Year = year;
            EditionYear = editionYear;
            Author = author;
            Deterioration = deterioration;

        }
        public int BookID { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public Editorial Editorial { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }
        public int EditionYear { get; set; }
        public Author Author { get; set; }
        public string Deterioration { get; set; }
    }
}
