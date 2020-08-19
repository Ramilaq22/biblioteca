using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public interface ILoanController
    {
        Loan AddLoan(Loan loan);
        List<Loan> FilteredList();
        Loan EditLoan(Loan loan);
        List<Loan> GetAll();
    }
}
