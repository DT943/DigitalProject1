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
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace BranchesManagement.Data.DbContext
{
    public class BranchesManagementDbContext : BaseDbContext<BranchesManagementDbContext>
    {
        private readonly IConfiguration _configuration;

        public BranchesManagementDbContext(DbContextOptions<BranchesManagementDbContext> options, IConfiguration configuration)
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

         public DbSet<Domain.Models.Branch> Branches { get; set; }

    }
}
