using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace Offer.Application.OfferAppService.Proccesors
{
    public class OfferProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.Offer>(p => p.Type).CanFilter().CanSort().HasName("type");
            mapper.Property<Domain.Models.Offer>(p => p.Name).CanFilter().CanSort().HasName("name");
            mapper.Property<Domain.Models.Offer>(p => p.CreatedBy).CanFilter().CanSort().HasName("createdby");

            mapper.Property<Domain.Models.Offer>(p => p.Code).CanFilter().CanSort();
            mapper.Property<Domain.Models.Offer>(p => p.CreatedDate).CanFilter().CanSort();
            mapper.Property<Domain.Models.Offer>(p => p.ModifiedDate).CanFilter().CanSort();

        }
    }
}
