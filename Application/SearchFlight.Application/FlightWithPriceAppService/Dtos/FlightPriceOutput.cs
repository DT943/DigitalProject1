using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlight.Application.FlightPricing.Dtos
{
    public class SegmentDto
    {
        public string FlightNumber { get; set; }
        public string Rph { get; set; }
        public string OriginCode { get; set; }
        public string DestinationCode { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string JourneyDuration { get; set; }
        public string Duration { get; set; }
        public string OriginCity { get; set; }
        public string OriginCountry { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationCountry { get; set; }
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
    }

    public class PricingDetailDto
    {
        public string PaxType { get; set; }
        public string BaseFare { get; set; }
        public string TotalTax { get; set; }
        public string TotalFees { get; set; }
        public string TotalFare { get; set; }
        public Dictionary<string, string> FareRuleReference { get; set; }
    }


}
