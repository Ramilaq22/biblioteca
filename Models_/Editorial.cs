using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    public class Editorial
    {
        public Editorial(int editorialID, string name)
        {
            EditorialID = editorialID;
            Name = name;
        }
        public int EditorialID { get; set; }
        public string Name { get; set; }
    }
}
