using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Purchase
    {
        public int Id { get; set; }
        public int SupplierID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int EmployeeID { get; set; }
    }
}
