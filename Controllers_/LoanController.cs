using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public class LoanController : ILoanController
    {
        LoanRepository loanRepository = new LoanRepository();
        public Loan AddLoan(Loan loan)
        {
            if (loanRepository.AddLoan(loan) == null)
            {
                return null;
            }

            return loan;
        }

        public Loan EditLoan(Loan loan)
        {
            if (loanRepository.EditLoan(loan) == null)
            {
                return null;
            }

            return loan;
        }

        public List<Loan> FilteredList()
        {
            return loanRepository.FilteredList();
        }

        public List<Loan> GetAll()
        {
            return loanRepository.GetAll();
        }
    }
}
