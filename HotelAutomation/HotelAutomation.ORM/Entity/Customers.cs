using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Customers
    {
        public Customers()
        {
            isActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public string IdentityNO { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public GenderType Gender { get; set; }
        public bool isActive { get; set; }
    }
    public enum MaritalStatusType
    {
        Single = 1,
        Married = 2
    }
    public enum GenderType
    {
        Female = 1,
        Male = 2,
    }
}
