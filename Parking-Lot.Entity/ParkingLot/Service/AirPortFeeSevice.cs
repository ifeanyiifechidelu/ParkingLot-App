using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Service
{
    public class AirPortFee : IFeeService
    {
        public decimal CalculateFee(TimeSpan duration)
        {
            if (duration.TotalDays < 1)
                return 0;
            else if (duration.TotalDays < 8)
                return (decimal)Math.Ceiling(duration.TotalDays) * 80;
            else
                return (decimal)Math.Ceiling(duration.TotalDays) * 100;
        }
    }
}