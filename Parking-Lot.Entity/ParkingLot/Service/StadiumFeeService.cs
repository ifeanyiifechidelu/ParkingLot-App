using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Service
{
    public class StadiumFee : IFee
    {
        public decimal CalculateFee(TimeSpan duration)
        {
            if (duration.TotalHours < 4)
                return 30;
            else if (duration.TotalHours < 12)
                return 60;
            else
                return 60 + ((decimal)Math.Ceiling(duration.TotalHours - 12) * 100);
        }
    }
}