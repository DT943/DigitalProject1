using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Offer.Application.FlightOfferAppService.Dtos
{
    public class FlightOfferCreateDto : IValidatableDto
    {
        public int OfferID { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }

        public string POS { get; set; }

        public string TripType { get; set; }

        public string ClassType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class FlightOfferUpdateDto : IEntityUpdateDto
    {
        public int OfferID { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }

        public string POS { get; set; }

        public string TripType { get; set; }

        public string ClassType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}


