using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Offer.Domain.Models
{
    public class FlightOffer : BasicEntityWithAuditInfo
    {
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        public Offer Offer;
        public string Type { get; set; }
        public string IPAddress { get; set; }

        public string POS {  get; set; }

        public string TripType { get; set; }

        public string ClassType { get; set; }
        public string OfferFor { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
