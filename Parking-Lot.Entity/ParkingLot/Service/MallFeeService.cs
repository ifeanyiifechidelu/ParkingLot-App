using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Service
{
    public class MallFee : IFee
    {
        public decimal CalculateFee(TimeSpan duration)
        {
            if (duration.TotalHours <= 4)
                return 10;
            else
                return 10 + ((decimal)Math.Ceiling(duration.TotalHours - 4) * 20);
        }
    }
}