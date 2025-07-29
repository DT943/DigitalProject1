using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlight.Application.FlightPricing.Dtos
{
    public class FlightPriceCreateDto
    {
        public int OriginId { get; set; } = 0;
        public int DestinationId { get; set; } = 0;
        public string Date { get; set; } = string.Empty;
        public string DateReturn { get; set; } = string.Empty;
        public int Adults { get; set; } = 0;
        public int Children { get; set; } = 0;
        public int Infants { get; set; } = 0;
        public string FlightClass { get; set; } = string.Empty;
        public string FlightType { get; set; } = string.Empty;
        public string Pos { get; set; } = string.Empty;
    }

}
