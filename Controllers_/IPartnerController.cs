using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public interface IPartnerController
    {
        Partner AddPartner(Partner partner);
        Partner GetByID(int ID);
        Partner CheckPartner(string partnerDNI);
        List<Partner> GetAll();
    }
}
