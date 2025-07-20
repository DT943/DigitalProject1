using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class PaymentPNRResult: BasicEntity
    {
        public string SessionId { get; set; }

        public string? TicketAdvisory { get; set; }
        public string? PNR { get; set; }

        public float? BaseFareAmount { get; set; }
        public float? BaseFareCurrency { get; set; }
        public float? TotalFareAmount { get; set; }
        public float? TotalFareCurrency { get; set; }
        public float? TotalEquivFareAmount { get; set; }
        public float? TotalEquivFareCurrency { get; set; }

        public string? CompanyName { get; set; }

        public float? PaymentAmount { get; set; }

        public string? PaymentCurrency { get; set; }

        public float? PaymentAmountInPayCurAmount  { get; set; }
        public string? PaymentAmountInPayCurCurrency    { get; set; }


        public string? TicketingStatus { get; set; }
        public string? TicketType { get; set; }

        public int? NumberOfADT {  get; set; }
        public int? NumberOfCHD { get; set; }
        public int? NumberOfINF { get; set; }

        public ICollection<PaymentPNRFlightSegment>? Segments { get; set; } 
        public ICollection<PaymentPNRPassenger>? Passengers { get; set; } 
        public ICollection<PaymentPNRTax>? Taxes { get; set; } 
        public ICollection<PaymentPNRFee>? Fees { get; set; }
        public ICollection<PaymentPNRETicketInfo>? ETickets { get; set; }
        public int? ContactId { get; set; }
        [ForeignKey("ContactId")]
        public PaymentPNRContact? Contact { get; set; }

    }
    public class PaymentPNRContact
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? MobileNumber { get; set; }

        public string? CountryCode { get; set; }
        public string? AreaCode { get; set; }

        public string? Email { get; set; }

        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? CountryIsoCode { get; set; }
        public string? PreferredLanguage { get; set; }

    }
    public class PaymentPNRFlightSegment
    {
        [Key]
        public int Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? DepartureAirportCode { get; set; }
        public string? ArrivalAirportCode { get; set; }
        public string? DepartureDateTime { get; set; }
        public string? ArrivalDateTime { get; set; }
        public string? Terminal { get; set; }
        public string? CabinClass { get; set; }
        public string? Status { get; set; }
        public string? RPH { get; set; }
        public string? Comment { get; set; }

        public int paymentPNRResultId { get; set; }
        [ForeignKey("paymentPNRResultId")]
        public PaymentPNRResult paymentPNRResult { get; set; }
    }

    public class PaymentPNRPassenger
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Nationality { get; set; }
        public string? TypeCode { get; set; }
        public int paymentPNRResultId { get; set; }
        [ForeignKey("paymentPNRResultId")]
        public PaymentPNRResult paymentPNRResult { get; set; }

    }

    public class PaymentPNRTax
    {
        [Key]
        public int Id { get; set; }
        public string? TaxCode { get; set; }
        public float? Amount { get; set; }
        public string? Currency { get; set; }
        public int paymentPNRResultId { get; set; }
        [ForeignKey("paymentPNRResultId")]
        public PaymentPNRResult paymentPNRResult { get; set; }

    }

    public class PaymentPNRFee
    {
        [Key]
        public int Id { get; set; }

        public string? FeeCode { get; set; }
        public float? Amount { get; set; }
        public string? Currency { get; set; }
        public int paymentPNRResultId { get; set; }
        [ForeignKey("paymentPNRResultId")]
        public PaymentPNRResult paymentPNRResult { get; set; }

    }

    public class PaymentPNRETicketInfo
    {
        [Key]
        public int Id { get; set; }
        public string? ETicketNumber { get; set; }
        public string? CouponNumber { get; set; }
        public string? FlightSegmentRPH { get; set; }
        public string? TicketStatus { get; set; }
        public string? UsedStatus { get; set; }
        public int paymentPNRResultId { get; set; }
        [ForeignKey("paymentPNRResultId")]
        public PaymentPNRResult paymentPNRResult { get; set; }

    }

}
