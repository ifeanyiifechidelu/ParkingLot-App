// See https://aka.ms/new-console-template for more information
using Parking_Lot.Infrastructure.Transaction.Service;
using Parking_Lot.Entity.ParkingLot.Entity;
using Parking_Lot.Entity.Transaction.Entity;

    // Example usage
    ParkingLotService parkingLot = new(100, 80, 40, 20);

    // Park vehicles
    Vehicle motorcycle = new() { Type = VehicleType.Motorcycle, Size = 1 };
    ParkingTicket ticket1 = parkingLot.ParkVehicle(motorcycle);

    Vehicle scooter = new() { Type = VehicleType.Motorcycle, Size = 1 };
    ParkingTicket ticket2 = parkingLot.ParkVehicle(scooter);

    Vehicle car = new() { Type = VehicleType.Car, Size = 1 };
    ParkingTicket ticket3 = parkingLot.ParkVehicle(car);

    // Unpark vehicles
    ParkingReceipt receipt1 = parkingLot.UnparkVehicle(ticket2);
    ParkingReceipt receipt2 = parkingLot.UnparkVehicle(ticket1);

    Console.WriteLine("Receipt 1 - Fee: " + receipt1.Fee);
    Console.WriteLine("Receipt 2 - Fee: " + receipt2.Fee);
