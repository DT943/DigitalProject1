using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace HR.Application.CandidateAppService.Processors
{
    public class CandidateProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.Candidate>(p => p.JobAppliedFor).CanFilter().CanSort().HasName("jobappliedfor");

            mapper.Property<Domain.Models.Candidate>(p => p.IsDeleted).CanFilter().CanSort().HasName("isdeleted");

        }
    }
}
