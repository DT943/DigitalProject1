using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Application.FlightOfferAppService.Dtos
{
    public class FlightOfferGetDto
    {
        public int OfferID { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }

        public string POS { get; set; }

        public string TripType { get; set; }

        public string TicketType { get; set; }

        public string ClassType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
