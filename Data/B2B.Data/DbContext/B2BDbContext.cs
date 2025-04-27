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
using System.DirectoryServices.ActiveDirectory;

namespace B2B.Data.DbContext
{
    public class B2BDbContext : BaseDbContext<B2BDbContext>
    {
        private readonly IConfiguration _configuration;

        public B2BDbContext(DbContextOptions<B2BDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasDefaultSchema(GetSchemaName());

        }

        public DbSet<Domain.Models.TravelAgentOffice> TravelAgentOffices { get; set; }
        public DbSet<Domain.Models.TravelAgentApplication> TravelAgentApplications { get; set; }
        public DbSet<Domain.Models.EmployeeApplication> EmployeeApplications { get; set; }
    }
}
