using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class SalesDetails
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
    }
}
