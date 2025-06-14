using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.TierPricingBundlesAppService.Dtos
{
    public class TierPricingBundlesCreateDto : IValidatableDto
    {
        public int NumberOfDays { get; set; }

        public int PriceInUsd { get; set; }
    }

    public class TierPricingBundlesUpdateDto : IEntityUpdateDto
    {
        public int NumberOfDays { get; set; }

        public int PriceInUsd { get; set; }
    }
}
