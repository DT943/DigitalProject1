using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos
{

    public class InquirePNRGetDto
    {
        public string Status { get; set; } = "success";
        public List<string> Errors { get; set; }
        public string BookingReference { get; set; }
        public DateTime TicketTimeLimit { get; set; }
        public string TicketAdvisory { get; set; }
        public List<BookFlightSegmentDto> Segments { get; set; }
        public BookFareDto Fare { get; set; }
        public List<BookPassengerDto> Passengers { get; set; }
        public BookContactInfoDto ContactInfo { get; set; }
        public BookPassengerCountDto PassengerCounts { get; set; }
    }

    public class BookFlightSegmentDto
    {
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string DepartureTerminal { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string CabinClass { get; set; }
        public string Rph { get; set; }
    }

    public class BookFareDto
    {
        public decimal BaseFare { get; set; }
        public decimal Tax { get; set; }
        public decimal Fee { get; set; }
        public decimal TotalFareUSD { get; set; }
        public decimal TotalFareSYP { get; set; }
        public decimal TotalFareWithCCFeeUSD { get; set; }
        public decimal TotalFareWithCCFeeSYP { get; set; }
    }

    public class BookPassengerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string PassengerType { get; set; }
        public string Nationality { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string DocumentIssueCountry { get; set; }
        public DateTime DocumentExpiry { get; set; }
        public string PhoneNumber { get; set; }
        public string Rph { get; set; }
    }

    public class BookContactInfoDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string PreferredLanguage { get; set; }
    }

    public class BookPassengerCountDto
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
    }

}
