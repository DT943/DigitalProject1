using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class TierPricingBundles : BasicEntity
    {
        public int NumberOfDays { get; set; }

        public int PriceInUsd { get; set; }

    }
}
