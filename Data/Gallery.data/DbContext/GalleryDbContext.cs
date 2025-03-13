using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Gallery.Data.DbContext
{
    public class GalleryDbContext : BaseDbContext<GalleryDbContext>
    {
        private readonly IConfiguration _configuration;

        public GalleryDbContext(DbContextOptions<GalleryDbContext> options, IConfiguration configuration) : base(options)
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

        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<Domain.Models.Gallery> Galleries { get; set; }
    }
}
