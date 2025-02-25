using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Domain.Models
{
    public class ChammilesOffer
    {
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        public Offer Offer;
    }
}
