using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data.BaseDbContext;

namespace Loyalty.Data.DbContext
{
    public class LoyaltyDbContext : BaseDbContext<LoyaltyDbContext>
    {
        private readonly IConfiguration _configuration;

        public LoyaltyDbContext(DbContextOptions<LoyaltyDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.HasDefaultSchema(GetSchemaName());
        }
        public DbSet<Domain.Models.MemberAddressDetails> MemberAddressDetails { get; set; }
        public DbSet<Domain.Models.MemberDemographicsAndProfile> MemberDemographicsAndProfiles { get; set; }
        public DbSet<Domain.Models.MemberTelephoneDetails> MemberTelephoneDetails { get; set; }


    }
}
