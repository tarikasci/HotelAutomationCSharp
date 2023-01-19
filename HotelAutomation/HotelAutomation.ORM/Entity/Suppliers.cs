using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Suppliers
    {
        public Suppliers()
        {
            isActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public bool isActive { get; set; }
    }
}
