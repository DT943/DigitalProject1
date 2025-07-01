using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sieve.Services;

namespace Authentication.Application.Processors
{
    public class AuthenticationProcessorConfiguration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Domain.Models.ApplicationUser>(p => p.FirstName).CanFilter().CanSort().HasName("firstname");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.NormalizedUserName).CanFilter().CanSort().HasName("username");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.Id).CanFilter().CanSort().HasName("id");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.NormalizedEmail).CanFilter().CanSort().HasName("email");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.LastName).CanFilter().CanSort().HasName("lastname");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.IsActive).CanFilter().CanSort().HasName("isactive");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.IsDeleted).CanFilter().CanSort().HasName("isdeleted");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.IsFrozed).CanFilter().CanSort().HasName("isfrozed");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.IsLocked).CanFilter().CanSort().HasName("islocked");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.Department).CanFilter().CanSort().HasName("department");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.Code).CanFilter().CanSort().HasName("code");
            mapper.Property<Domain.Models.ApplicationUser>(p => p.Search).CanFilter();

        }
    }
}