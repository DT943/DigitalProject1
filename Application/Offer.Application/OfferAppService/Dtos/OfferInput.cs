using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Offer.Application.OfferAppService.Dtos
{
    public class OfferCreateDto : IValidatableDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Segment { get; set; }
        public bool Membership { get; set; }
    }

    public class OfferUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Segment { get; set; }
        public bool Membership { get; set; }

    }
}
