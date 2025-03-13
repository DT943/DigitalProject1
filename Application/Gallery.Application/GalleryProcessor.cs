using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Gallery.Application
{
    public class GalleryProcessor : SieveProcessor
    {
        public GalleryProcessor(IOptions<SieveOptions> options) : base(options) { }
        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            return mapper.ApplyConfigurationsFromAssembly(typeof(GalleryProcessor).Assembly);
        }
    }
}
