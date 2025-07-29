using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PDFTicketAppService.Dtos
{
    public class PDFTicketCreateDto
    {
        public string SessionId { get; set; }
        public string PNR { get; set; }

        public string DateOfBooking { get; set; }

      
        public string PaidAmountUSD { get; set; }

        public string ChargesUSD { get; set; }

        public string FareUSD { get; set; }

        public string BalanceUSD { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string ContactEmail { get; set; }


        public string ContactPhone { get; set; }
        public string ContactAreaCode { get; set; }
        public string ContactCountryCode { get; set; }


        public List<FlightSegmentCreateDto>  FlightSegments { get; set; }

        public List<PassengerTicketInfo> PassengerTicketInfos { get; set; }
        public List<FareRuleCreateDto> FareRules  { get; set; }

        

    }
    public class FlightSegmentCreateDto
    {

        public string FlightNumber { get; set; }
        public string OriginAirPort { get; set; }
        public string DestinationAirPort { get; set; }
        public string Duration { get; set; }
        public string Terminal { get; set; }
        public string Aircraft { get; set; }

        public string DepartureDate { get; set; }

        public string ArrivalDate { get; set; }


        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }


        public string FlightClass { get; set; }

        public string Status { get; set; }

        public string CheckInFromDate { get; set; }

        public string CheckInFromTime { get; set; }


    }
    public class FareRuleCreateDto
    {
        public string Origin_Destination {  get; set; }

        public string FareBasisCode { get; set; }

        public string TermsAndConditions { get; set; }

    }
    public class PassengerTicketInfo
    {
        public string PassengerType { get; set; }  //BABY, Child, Adult
        public string PassengerTitle { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }

        public string PassengerDateOfBirth { get; set; }

        public string Fare { get; set; }

        public string FareCurrency { get; set; }

        public string Charges { get; set; }

        public string ChargesCurrency { get; set; }

        public string PaidAmount { get; set; }

        public string PaidAmountCurrency { get; set; }

        public string Balance { get; set; }

        public string BalanceCurrency { get; set; }

    }

}
