using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos
{

    public class BookGetDto
    {
        public string Status { get; set; } = "success";
        public string PNR { get; set; }
        public List<string> Errors { get; set; }
        public List<FlightSegment> FlightSegments { get; set; }

    }
    public class FlightSegment
    {
        public string FlightNumber { get; set; }
        public string DepartureDateTime { get; set; }
        public string ArrivalDateTime { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Status { get; set; }
    }


}
