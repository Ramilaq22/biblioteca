using EJ01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public class EditorialController : IEditorialController
    {
        EditorialRepository editorialRepository = new EditorialRepository();
        public Editorial AddEditorial(Editorial editorial)
        {
            foreach (Editorial aux in editorialRepository.GetAll())
            {
                if ((editorial.Name == aux.Name) || (editorial.EditorialID == aux.EditorialID))
                {
                    return null;
                }
            }

            if (editorialRepository.AddEditorial(editorial) == null)
            {
                return null;
            }

            return editorial;
        }
        public List<Editorial> GetAll()
        {
            return editorialRepository.GetAll();
        }
    }
}
