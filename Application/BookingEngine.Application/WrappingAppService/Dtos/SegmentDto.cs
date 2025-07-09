using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.WrappingAppService.Dtos
{
    public class SegmentModel
    {
        public string departure_date { get; set; }
        public string departure_time { get; set; }
        public string arrival_date { get; set; }
        public string arrival_time { get; set; }
        public string FlightNumber { get; set; }
        public string rph { get; set; }
        public string origin_code { get; set; }
        public string destination_code { get; set; }
    }
}
