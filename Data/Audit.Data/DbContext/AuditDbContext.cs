using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audit.Data.DbContext
{
    using System.Reflection.Emit;
    using Audit.Domain;
    using Microsoft.EntityFrameworkCore;

    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<AuditDetails> AuditLogs { get; set; }

    }

}
