using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01.Controllers
{
    public class PartnerController : IPartnerController
    {
        PartnerRepository partnerRepository = new PartnerRepository();
        public Partner AddPartner(Partner partner)
        {
            try
            {
                if (partnerRepository.AddPartner(partner) == null)
                {
                    return null;
                }

                return partner;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Partner GetByID(int ID)
        {
            try
            {
                return partnerRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Partner CheckPartner(string partnerDNI)
        {
            try
            {
                return partnerRepository.CheckPartner(partnerDNI);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public List<Partner> GetAll()
        {
            try
            {
                return partnerRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
