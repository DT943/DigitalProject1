using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Domain.Models
{
    public class LuxuryHoliday : BasicEntityWithAuditInfo
    {
        [ForeignKey("HolidayOffer")]

        public int HolidayOfferId { get; set; }
        public HolidayOffer HolidayOffer { get; set; }

        public List<Domain.Models.Rule> Rules { get; set; }
        public FlightOffer FlightOffer { get; set; }
        public string Transportation { get; set; }

        public string HotelCode { get; set; }

    }
}
