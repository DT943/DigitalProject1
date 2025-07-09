using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class Reservation: BasicEntityWithAuditAndFakeDelete
    {

        public string Pos { get; set; }
        public string TransactionId { get; set; }
        public string PNR { get; set; }
        public string PaymentAmount { get; set; } 
        public string FlightType { get; set; }
        public string FlightClass { get; set; }
        public ICollection<Contact> ContactInfo { get; set; }
        public string CheckOutUrl { get; set; }


    }
}
