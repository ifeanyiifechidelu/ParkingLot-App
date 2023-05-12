using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Entity
{
    public class ParkingSpot
    {
        public int Number { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}