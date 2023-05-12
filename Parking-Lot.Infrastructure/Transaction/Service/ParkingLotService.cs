using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking_Lot.Entity.Transaction.Interface;
using Parking_Lot.Entity.ParkingLot.Entity;
using Parking_Lot.Entity.ParkingLot.Service;
using Parking_Lot.Entity.Transaction.Entity;

namespace Parking_Lot.Infrastructure.Transaction.Service
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly Dictionary<VehicleType, List<ParkingSpot>> _spots;

        public ParkingLotService(int motorcycleSpots, int carSpots, int busTruckSpots)
        {
            _spots = new Dictionary<VehicleType, List<ParkingSpot>>
            {
                [VehicleType.Motorcycle] = InitializeSpots(motorcycleSpots),
                [VehicleType.Car] = InitializeSpots(carSpots),
                [VehicleType.Bus] = InitializeSpots(busTruckSpots),
                [VehicleType.Truck] = InitializeSpots(busTruckSpots)
            };
        }

        public List<ParkingSpot> InitializeSpots(int count)
        {
            var parkingSpots = new List<ParkingSpot>();
            for (int i = 1; i <= count; i++)
            {
                parkingSpots.Add(new ParkingSpot { Number = i });
            }
            return parkingSpots;
        }

        public ParkingTicket ParkVehicle(Vehicle vehicle)
        {
            if (!_spots.ContainsKey(vehicle.Type) || _spots[vehicle.Type].Count == 0)
                throw new Exception("No available _spots for the specified vehicle type.");

            var spot = _spots[vehicle.Type][0];
            _spots[vehicle.Type].Remove(spot);

            var ticket = new ParkingTicket
            {
                TicketNumber = "T-" + Guid.NewGuid().ToString(),
                SpotNumber = spot.Number,
                EntryDateTime = DateTime.Now
            };

            spot.Vehicle = vehicle;

            return ticket;
        }

        public ParkingReceipt UnparkVehicle(ParkingTicket ticket)
        {
            if (!_spots.ContainsKey(ticket.Vehicle.Type) || ticket.Vehicle == null)
                throw new Exception("Invalid parking ticket. Vehicle type not found in _spots dictionary or vehicle is null.");

            var spots = _spots[ticket.Vehicle.Type];
            var spot = spots?.Find(s => s.Number == ticket.SpotNumber) ?? throw new Exception("Invalid parking ticket. Spot not found.");
            spots.Insert(ticket.SpotNumber - 1, spot);
            spot.Vehicle = null;

            var receipt = new ParkingReceipt
            {
                ReceiptNumber = "R-" + Guid.NewGuid().ToString(),
                EntryDateTime = ticket.EntryDateTime,
                ExitDateTime = DateTime.Now,
                Fee = CalculateFee(ticket.Vehicle.Type, ticket.EntryDateTime, DateTime.Now)
            };

            return receipt;
        }

        public decimal CalculateFee(VehicleType vehicleType, DateTime entryDateTime, DateTime exitDateTime)
        {
            TimeSpan duration = exitDateTime - entryDateTime;
            Fee feeModel = vehicleType switch
            {
                VehicleType.Motorcycle or VehicleType.Car => new MallFee(),
                VehicleType.Bus or VehicleType.Truck => new StadiumFee(),
                _ => throw new ArgumentException("Invalid vehicle type"),
            };
            return feeModel.CalculateFee(duration);
        }
    }
}