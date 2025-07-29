using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.ReservationInfo.Dtos
{
    public class ReservationCreateDto : IValidatableDto
    {
        public string Pos { get; set; }
        public string TransactionId { get; set; }
        public string PNR { get; set; }
        public string PaymentAmount { get; set; }
        public string FlightType { get; set; }
        public string FlightClass { get; set; }
        public string CheckOutUrl { get; set; }
        public string PaymentStatus { get; set; } = "unpaid";
        public ContactInfoCreateDto ContactInfo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }

    public class ReservationUpdateDto : IEntityUpdateDto
    {
        public string Pos { get; set; }
        public string TransactionId { get; set; }
        public string PNR { get; set; }
        public string PaymentAmount { get; set; }
        public string FlightType { get; set; }
        public string FlightClass { get; set; }
        public string CheckOutUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;



        public ContactInfoCreateDto ContactInfo { get; set; }
    }


}
