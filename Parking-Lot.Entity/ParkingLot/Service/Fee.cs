using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Service
{
    public abstract class Fee
    {
        public abstract decimal CalculateFee(TimeSpan duration);
    }
}