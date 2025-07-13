using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class InquirePNR : BasicEntity
    {
        public string? LastName { get; set; }
        public string? PNR { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        public int? InquirePNRResponseId { get; set; }
        [ForeignKey("InquirePNRResponseId")]
        public InquirePNRResponse? inquirePNRResponse { get; set; }
    }

    public class InquirePNRResponse
    {
        [Key]
        public int Id { get; set; }

        public string? TransactionIdentifier { get; set; }
        public string? Status { get; set; } = "success";
        public List<string>? Errors { get; set; }
        public string? BookingReference { get; set; }
        public DateTime? TicketTimeLimit { get; set; }
        public string? TicketAdvisory { get; set; }
        public List<BookFlightSegment>? Segments { get; set; }

        public int? FareId { get; set; }
        [ForeignKey("FareId")]
        public BookFare? Fare { get; set; }

        public List<BookPassenger>? Passengers { get; set; }

        public int? ContactInfoId { get; set; }
        [ForeignKey("ContactInfoId")]
        public BookContactInfo? ContactInfo { get; set; }

        public int? PassengerCountsId { get; set; }
        [ForeignKey("PassengerCountsId")]
        public BookPassengerCount? PassengerCounts { get; set; }
    }

    public class BookFlightSegment
    {
        [Key]
        public int Id { get; set; }

        public string? Status { get; set; }
        public string? FlightNumber { get; set; }
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }
        public string? DepartureTerminal { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public string? CabinClass { get; set; }
        public string? Rph { get; set; }

        public int? InquirePNRResponseId { get; set; }
        [ForeignKey("InquirePNRResponseId")]
        public InquirePNRResponse? inquirePNRResponse { get; set; }
    }

    public class BookFare
    {
        [Key]
        public int Id { get; set; }

        public decimal? BaseFare { get; set; }
        public List<BookTax>? Taxes { get; set; }
        public List<BookFee>? Fees { get; set; }
        public decimal? TotalFare { get; set; }
        public decimal? TotalEquivFare { get; set; }
    }

    public class BookPassenger
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? PassengerType { get; set; }
        public string? Nationality { get; set; }
        public string? DocumentNumber { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentIssueCountry { get; set; }
        public DateTime? DocumentExpiry { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Rph { get; set; }
        public List<BookETicket>? ETicketInfo { get; set; }

        public int? InquirePNRResponseId { get; set; }
        [ForeignKey("InquirePNRResponseId")]
        public InquirePNRResponse? inquirePNRResponse { get; set; }
    }

    public class BookETicket
    {
        [Key]
        public int Id { get; set; }

        public string? CouponNumber { get; set; }
        public string? ETicketNumber { get; set; }
        public string? FlightSegmentCode { get; set; }
        public string? FlightSegmentRPH { get; set; }
        public string? Status { get; set; }
        public string? UsedStatus { get; set; }
    }

    public class BookContactInfo
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? CountryCode { get; set; }
        public string? PreferredLanguage { get; set; }
    }

    public class BookPassengerCount
    {
        [Key]
        public int Id { get; set; }

        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
    }

    public class BookTax
    {
        [Key]
        public int Id { get; set; }

        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? DecimalPlaces { get; set; }
        public string? TaxCode { get; set; }

        public int? BookFareId { get; set; }
        [ForeignKey("BookFareId")]
        public BookFare? BookFare { get; set; }
    }

    public class BookFee
    {
        [Key]
        public int Id { get; set; }

        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? DecimalPlaces { get; set; }
        public string? FeeCode { get; set; }

        public int? BookFareId { get; set; }
        [ForeignKey("BookFareId")]
        public BookFare? BookFare { get; set; }
    }
}
