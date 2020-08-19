using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Repositories
{
    public interface IEditorialRepository
    {
        Editorial AddEditorial(Editorial editorial);
        Editorial GetByID(int editorialID);
        List<Editorial> GetAll();
    }
}
