using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parking_Lot.Entity.ParkingLot.Entity;

namespace Parking_Lot.Entity.Transaction.Entity
{
    public class ParkingReceipt
    {
        public string? ReceiptNumber { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime ExitDateTime { get; set; }
        public decimal Fee { get; set; }
    }
}