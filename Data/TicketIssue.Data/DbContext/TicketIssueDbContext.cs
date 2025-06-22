using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TicketIssue.Data.DbContext
{
    public class TicketIssueDbContext : BaseDbContext<TicketIssueDbContext>
    {
        private readonly IConfiguration _configuration;

        public TicketIssueDbContext(DbContextOptions<TicketIssueDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.HasDefaultSchema(GetSchemaName());

        }

        public DbSet<Domain.Models.TicketIssue> TicketIssues { get; set; }

    }
}
