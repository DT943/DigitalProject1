using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Authentication.Application
{
    public class AuthenticationProcessor : SieveProcessor
    {
        public AuthenticationProcessor(IOptions<SieveOptions> options) : base(options) { }
        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            return mapper.ApplyConfigurationsFromAssembly(typeof(AuthenticationProcessor).Assembly);
        }
    }
}
