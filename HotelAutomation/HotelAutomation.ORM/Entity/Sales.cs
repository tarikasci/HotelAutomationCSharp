using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Sales
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int RoomID { get; set; }
        public decimal RoomPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
