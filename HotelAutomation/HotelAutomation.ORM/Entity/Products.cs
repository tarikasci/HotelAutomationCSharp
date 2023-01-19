using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Products
    {
        public Products()
        {
            isActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public int CategoryID { get; set; }
        public int UnitTypeID { get; set; }
        public bool isActive { get; set; }

    }
}
