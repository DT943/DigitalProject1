using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CMS.Data.DbContext
{
    public class CMSDbContext : BaseDbContext<CMSDbContext>
    {
        private readonly IConfiguration _configuration;

        public CMSDbContext(DbContextOptions<CMSDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override string GetSchemaName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name.Split('.')[0].ToUpper();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(GetSchemaName());

        }

        public DbSet<Domain.Models.Component> Components { get; set; }
        public DbSet<Domain.Models.StaticComponent> StaticComponents { get; set; }

        public DbSet<Domain.Models.ComponentMetadata> ComponentMetadatas { get; set; }

        public DbSet<Domain.Models.Page> Pages { get; set; }

        public DbSet<Domain.Models.Segment> Segments { get; set; }
        //CustomForms
        public DbSet<Domain.Models.CustomForm> CustomForms { get; set; }


    }
}
