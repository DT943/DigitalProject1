using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class Reservation: BasicEntity
    {

        public string Pos { get; set; }
        public string TransactionId { get; set; }
        public string PNR { get; set; }
        public string PaymentAmount { get; set; } 
        public string FlightType { get; set; }
        public string FlightClass { get; set; }

        public int ContactInfoId { get; set; }
        [ForeignKey("ContactInfoId")]

        public Contact ContactInfo { get; set; }
        public string PaymentStatus { get; set; } = "unpaid";

        public string CheckOutUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    }
}
