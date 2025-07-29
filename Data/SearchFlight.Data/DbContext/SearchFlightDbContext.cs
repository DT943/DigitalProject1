using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SearchFlight.Data.DbContext
{
    public class SearchFlightDbContext : BaseDbContext<SearchFlightDbContext>
    {
        private readonly IConfiguration _configuration;

        public SearchFlightDbContext(DbContextOptions<SearchFlightDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.HasDefaultSchema(GetSchemaName());

        }

    }
}
