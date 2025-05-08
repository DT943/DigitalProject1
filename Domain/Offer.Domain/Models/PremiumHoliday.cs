using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Domain.Models
{
    public class PremiumHoliday : BasicEntityWithAuditInfo
    {
        [ForeignKey("HolidayOffer")]

        public int HolidayOfferId { get; set; }
        public HolidayOffer HolidayOffer { get; set; }

        public FlightOffer FlightOffer { get; set; }
        public string HotelCode { get; set; }
    }
}
