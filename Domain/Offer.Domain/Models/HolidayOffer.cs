using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Offer.Domain.Models
{
    public class HolidayOffer : BasicEntityWithAuditInfo
    {
        public DateTime HolidayDate;

        [ForeignKey("Offer")]
        public int OfferID { get; set; }

        public Offer Offer;


        
    }
}
