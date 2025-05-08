using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace CMS.Application.PageAppService.Processors
{
    public class PageProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.Page>(p => p.POS).CanFilter().CanSort().HasName("pos");
            mapper.Property<Domain.Models.Page>(p => p.Id).CanFilter().CanSort().HasName("id");
            mapper.Property<Domain.Models.Page>(p => p.CreatedBy).CanFilter().CanSort().HasName("createdby");
            mapper.Property<Domain.Models.Page>(p => p.CreatedDate).CanFilter().CanSort().HasName("createddate");
            mapper.Property<Domain.Models.Page>(p => p.ModifiedBy).CanFilter().CanSort().HasName("modifiedby");
            mapper.Property<Domain.Models.Page>(p => p.ModifiedDate).CanFilter().CanSort().HasName("modifieddate");
            mapper.Property<Domain.Models.Page>(p => p.Language).CanFilter().CanSort().HasName("language");


            mapper.Property<Domain.Models.StaticComponent>(p => p.Language).CanFilter().CanSort().HasName("language");
 


        }
    }
}
