using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Partner
    {
        public Partner(int partnerID, string lastName, string firstName, string DNI, string address, string phone)
        {
            PartnerID = partnerID;
            LastName = lastName;
            FirstName = firstName;
            this.DNI = DNI;
            Address = address;
            Phone = phone;
        }
        public int PartnerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DNI { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
