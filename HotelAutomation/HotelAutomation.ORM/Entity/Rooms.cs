using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class Rooms
    {
        public Rooms()
        {
            isActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomTypeID { get; set; }
        public bool isActive { get; set; }
    }
}
