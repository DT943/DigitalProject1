using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AuditAppService.Dtos
{
    public class InquirePNRAuditCreateDto : IValidatableDto
    {
        public string LastName { get; set; }

        public string PNR { get; set; }
        public DateTime CreatedAt { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public InquirePNRCreateDto InquirePNRRsponseDto { get; set; }

    }


        public class InquirePNRCreateDto : IValidatableDto
    {
            public string TransactionIdentifier { get; set; }
            public string Status { get; set; } = "success";
            public List<string> Errors { get; set; }
            public string BookingReference { get; set; }
            public DateTime TicketTimeLimit { get; set; }
            public string TicketAdvisory { get; set; }
            public List<BookFlightSegmentCreateDto> Segments { get; set; }
            public BookFareCreateDto Fare { get; set; }
            public List<BookPassengerCreateDto> Passengers { get; set; }
            public BookContactInfoCreateDto ContactInfo { get; set; }
            public BookPassengerCountCreateDto PassengerCounts { get; set; }
        }

        public class BookFlightSegmentCreateDto: IValidatableDto
    {
            public string Status { get; set; }
            public string FlightNumber { get; set; }
            public string DepartureAirport { get; set; }
            public string ArrivalAirport { get; set; }
            public string DepartureTerminal { get; set; }
            public DateTime DepartureDateTime { get; set; }
            public DateTime ArrivalDateTime { get; set; }
            public string CabinClass { get; set; }
            public string Rph { get; set; }
        }

        public class BookFareCreateDto: IValidatableDto
    {
            public decimal BaseFare { get; set; }
            public List<BookTaxCreateDto> Taxes { get; set; }
            public List<BookFeeCreateDto> Fees { get; set; }
            public decimal TotalFare { get; set; }
            public decimal TotalEquivFare { get; set; }
        }

        public class BookPassengerCreateDto: IValidatableDto
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
            public List<BookETicketCreateDto> ETicketInfo { get; set; }

        }
        public class BookETicketCreateDto: IValidatableDto
    {
            public string CouponNumber { get; set; }
            public string ETicketNumber { get; set; }
            public string FlightSegmentCode { get; set; }
            public string FlightSegmentRPH { get; set; }
            public string Status { get; set; }
            public string UsedStatus { get; set; }
        }

        public class BookContactInfoCreateDto: IValidatableDto
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

        public class BookPassengerCountCreateDto: IValidatableDto
    {
            public int Adults { get; set; }
            public int Children { get; set; }
            public int Infants { get; set; }
        }

        public class BookTaxCreateDto: IValidatableDto
    {
            public decimal Amount { get; set; }
            public string CurrencyCode { get; set; }
            public int DecimalPlaces { get; set; }
            public string TaxCode { get; set; }

        }
        public class BookFeeCreateDto: IValidatableDto
        {
            public decimal Amount { get; set; }
            public string CurrencyCode { get; set; }
            public int DecimalPlaces { get; set; }
            public string FeeCode { get; set; }

        
        }
        public class InquirePNRUpdateDto : IEntityUpdateDto
        {

        }




}
