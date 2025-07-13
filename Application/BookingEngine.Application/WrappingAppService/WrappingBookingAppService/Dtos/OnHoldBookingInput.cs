using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.ReservationInfo.Dtos;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos
{
    public class TravelerDocument
    {
        public string DocID { get; set; }
        public string ExpireDate { get; set; }
    }
    public class Segment
    {
        public string OriginCode { get; set; }
        public string DestinationCode { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string RPH { get; set; }
        public string JourneyDuration { get; set; }
        public string FlightNumber { get; set; }
    }

    public class BookCreateDto : IValidatableDto
    {
        public string TransactionId { get; set; }
        public List<Segment> Segments { get; set; }
        public string FlightClass { get; set; }
        public List<Dictionary<string, string>> Travelers { get; set; }
        public ContactInfoCreateDto ContactInfo { get; set; }
        public string PaymentAmount { get; set; }
        public string FlightType { get; set; }        
        public int PosId { get; set; }
    }
    public class BookUpdateDto : IEntityUpdateDto
    {
        public string TransactionId { get; set; }
        public List<Segment> Segments { get; set; }
        public string FlightClass { get; set; }
        public List<Dictionary<string, string>> Travelers { get; set; }
        public ContactInfoCreateDto ContactInfo { get; set; }
        public string PaymentAmount { get; set; }
        public string FlightType { get; set; }
        //public string CompanyName { get; set; }
        //public string OnAccount { get; set; }
        public string Pos { get; set; }
    }



}
