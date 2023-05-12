using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking_Lot.Entity.ParkingLot.Entity;
using Parking_Lot.Entity.Transaction.Entity;

namespace Parking_Lot.Entity.Transaction.Interface
{
    public interface IParkingLotService
    {
        List<ParkingSpot> InitializeSpots(int count);
        ParkingTicket ParkVehicle(Vehicle vehicle);
        ParkingReceipt UnparkVehicle(ParkingTicket ticket);
        decimal CalculateFee(VehicleType vehicleType, DateTime entryDateTime, DateTime exitDateTime);
    }
}