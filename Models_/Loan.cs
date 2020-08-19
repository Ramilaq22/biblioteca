using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Loan
    {        
        public string loanFull = "";
        public Loan(int loanID, Book book, Partner partner, DateTime loanDate, DateTime estimatedDate, DateTime devolutionDate)
        {
            LoanID = loanID;
            Book = book;
            Partner = partner;
            LoanDate = loanDate;
            EstimatedDate = estimatedDate;
            DevolutionDate = devolutionDate;
            loanFull = partner.DNI + " " + book.ISBN;
        }
        public int LoanID { get; set; }
        public Book Book { get; set; }
        public Partner Partner { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime DevolutionDate { get; set; }
    }
}
