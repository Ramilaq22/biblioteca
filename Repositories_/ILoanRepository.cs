using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Repositories
{
    public interface ILoanRepository
    {
        Loan AddLoan(Loan loan);
        List<Loan> FilteredList();
        Loan EditLoan(Loan loan);
        List<Loan> GetAll();
    }
}
