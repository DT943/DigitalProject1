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

namespace Event.Data.DbContext
{
    public class EventDbContext : BaseDbContext<EventDbContext>
    {
        private readonly IConfiguration _configuration;

        public EventDbContext(DbContextOptions<EventDbContext> options, IConfiguration configuration) : base(options)
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

        public DbSet<Domain.Models.Event> Events { get; set; }
        public DbSet<Domain.Models.Ticket> Tickets { get; set; }
        public DbSet<Domain.Models.TicketInventory> TicketInventory { get; set; }

    }
}
