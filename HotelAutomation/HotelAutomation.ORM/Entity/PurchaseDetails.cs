using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class PurchaseDetails
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
