using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Application.OfferAppService.Dtos
{
    public class OfferGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Segment { get; set; }
        public bool Membership { get; set; }
    }
}
