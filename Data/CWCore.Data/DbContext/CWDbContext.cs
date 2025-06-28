using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CWCore.Data.DbContext
{
    public class CWDbContext : BaseDbContext<CWDbContext>
    {  
        private readonly IConfiguration _configuration;

        public CWDbContext(DbContextOptions<CWDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(GetSchemaName());
        }
        public DbSet<Domain.Models.Language> Languages { get; set; }
        public DbSet<Domain.Models.POS> POSs { get; set; }


    }
}

