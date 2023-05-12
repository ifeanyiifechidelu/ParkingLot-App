using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking_Lot.Entity.ParkingLot.Entity;

namespace Parking_Lot.Entity.Transaction.Entity
{
    public class ParkingTicket
    {
        public string TicketNumber { get; set; } = null!;
        public int SpotNumber { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}