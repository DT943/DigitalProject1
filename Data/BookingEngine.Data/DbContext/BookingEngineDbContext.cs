using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Domain.Models;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookingEngine.Data.DbContext
{
    public class BookingEngineDbContext: BaseDbContext<BookingEngineDbContext>
    {
        private readonly IConfiguration _configuration;

        public BookingEngineDbContext(DbContextOptions<BookingEngineDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(GetSchemaName());
        }

        public DbSet<Domain.Models.AirPort> AirPorts { get; set; }

        public DbSet<AirPortTranslation> AirPortTranslations { get; set; }
        public DbSet<Domain.Models.SearchRequest> SearchRequests { get; set; }

    }
}
