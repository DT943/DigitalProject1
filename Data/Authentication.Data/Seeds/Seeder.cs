using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Seeds
{
    public static class Seeder
    {
        public static void Seed (this ModelBuilder builder)
        {
            var roles = new List<IdentityRole>();

            // Predefined role types
            var roleTypes = new List<string> { "Admin", "Manager", "Supervisor", "Officer" };

            // Iterate over each service and create roles for each
            foreach (var service in Enum.GetNames(typeof(Infrastructure.Domain.Consts.ServiceName)))
            {
                foreach (var roleType in roleTypes)
                {
                    var roleName = $"{service}-{roleType}"; // e.g., CMS-Admin, Offer-Manager
                    var role = new IdentityRole(roleName)
                    {
                        NormalizedName = roleName.ToUpper()
                    };
                    roles.Add(role);
                }
            }
            var superAdminRole = new IdentityRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            };

            roles.Add(superAdminRole);
            // Seed all roles into the database
            builder.Entity<IdentityRole>().HasData(roles);

            /*
            // **Seed Users**
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var adminUser = new IdentityUser
            {
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

            var managerUser = new IdentityUser
            {
                UserName = "manager@example.com",
                NormalizedUserName = "MANAGER@EXAMPLE.COM",
                Email = "manager@example.com",
                NormalizedEmail = "MANAGER@EXAMPLE.COM",
                EmailConfirmed = true
            };
            managerUser.PasswordHash = passwordHasher.HashPassword(managerUser, "Manager@123");

            // Seed users into the database
            builder.Entity<IdentityUser>().HasData(adminUser, managerUser);

            // **Seed User Roles** 
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id, // Will be auto-generated
                    RoleId = superAdminRole.Name // Use role name instead of ID
                },
                new IdentityUserRole<string>
                {
                    UserId = managerUser.Id,
                    RoleId = "CMS-Manager" // Example service role
                }
            );
            */

        }
    }
}
