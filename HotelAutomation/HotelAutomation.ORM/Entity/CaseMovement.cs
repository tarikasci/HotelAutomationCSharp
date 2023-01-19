using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAutomation.ORM.Entity
{
    public class CaseMovement
    {
        public int Id { get; set; }
        public int CaseID { get; set; }
        public int CaseMovementTypeID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
