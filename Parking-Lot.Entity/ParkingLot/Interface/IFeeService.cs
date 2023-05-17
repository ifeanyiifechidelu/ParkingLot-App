using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.Entity.ParkingLot.Service
{
    public interface IFeeService
    {
        public decimal CalculateFee(TimeSpan duration);
    }
}