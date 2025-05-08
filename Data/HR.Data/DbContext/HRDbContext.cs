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
namespace HR.Data.DbContext
{
    public class HRDbContext : BaseDbContext<HRDbContext>
    {
        private readonly IConfiguration _configuration;

        public HRDbContext(DbContextOptions<HRDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasDefaultSchema(GetSchemaName());
        }
        public DbSet<Domain.Models.JobPost> JobPosts { get; set; }

    }
}
