using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Offer.Data.DbContext
{
    public class OfferDbContext : BaseDbContext<OfferDbContext>
    {
        private readonly IConfiguration _configuration;

        public OfferDbContext(DbContextOptions<OfferDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.HasDefaultSchema(GetSchemaName());

        }

        public DbSet<Domain.Models.Offer> Offers { get; set; }
        public DbSet<Domain.Models.FlightOffer> FlightOffers { get; set; }
        public DbSet<Domain.Models.HolidayOffer> HolidayOffers { get; set; }
    }
}
