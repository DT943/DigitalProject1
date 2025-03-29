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

namespace Hotel.Data.DbContext
{
    public class HotelDbContext : BaseDbContext<HotelDbContext>
    {
        private readonly IConfiguration _configuration;

        public HotelDbContext(DbContextOptions<HotelDbContext> options, IConfiguration configuration)
            : base(options)
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
        public DbSet<Domain.Models.Hotel> Hotels { get; set; }
        public DbSet<Domain.Models.HotelGallery> HotelGalleries { get; set; }
        public DbSet<Domain.Models.ContactInfo> ContactInfo { get; set; }
        public DbSet<Domain.Models.Room> Rooms { get; set; }

    }
}
