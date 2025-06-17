using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace HR.Application.JobPostAppService.Processors
{
    public class JobPostProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.JobPost>(p => p.ClosingDate).CanFilter().CanSort().HasName("closingdate");
            mapper.Property<Domain.Models.JobPost>(p => p.IsDeleted).CanFilter().CanSort().HasName("isdeleted");

        }
    }
}
