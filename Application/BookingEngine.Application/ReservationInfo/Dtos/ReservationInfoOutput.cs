using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Application.ReservationInfo.Dtos
{

    public class ReservationGetDto
    {
        public int Id { get; set; }
        public string Pos { get; set; }
        public string TransactionId { get; set; }
        public string PNR { get; set; }
        public string PaymentAmount { get; set; }
        public string FlightType { get; set; }
        public string FlightClass { get; set; }
        public string CheckOutUrl { get; set; }

        public string PaymentStatus { get; set; }

        public ContactInfoGetDto ContactInfo { get; set; }

    }
}
