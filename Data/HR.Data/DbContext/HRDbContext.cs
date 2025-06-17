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
using HR.Domain.Models;
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

        }
        public DbSet<Domain.Models.JobPost> JobPosts { get; set; }
        public DbSet<Domain.Models.Candidate> Candidates { get; set; }
        public DbSet<Domain.Models.ProjectItem> ProjectItems { get; set; }

        public DbSet<Domain.Models.Application> Applications { get; set; }
        public DbSet<Domain.Models.EducationItem> EducationItems { get; set; }
        public DbSet<Domain.Models.ExperienceItem> ExperienceItems { get; set; }

        public DbSet<Domain.Models.Position> Positions { get; set; }

    }
}
