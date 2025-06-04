using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Authentication.Domain.Models;

namespace Authentication.Data.Seeds
{
    /*
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

        }
    }
            */
    public static class UserRoleSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // User IDs
            var userIds = new List<string>
            {
                /*
                "45c58809-6f06-490f-8f66-07f7b7605489",
                "4bfd8d34-3c82-4687-9f7b-512588f0e89a",
                "b5f09407-0a62-4e16-8fe1-0f81fedee023",
                "ddd53e03-5c26-486a-86c7-8e4da00f101d"
                */
            };

            // Role IDs
            var roleIds = new List<string>
            {
                /*
                "8df6e747-6a64-4de6-98eb-540e4e2042ce",
                "a646ebf6-8805-4608-af95-a8e30bc07a20",
                "aae4a697-437e-4c77-b8bd-ec303e750fa0",
                "acb4e87d-077a-489c-8322-1b303f6ee5ae",
                "d689c605-6690-4bd9-8787-c3ac496c8b63",
                "eb1e71e7-f856-49ac-b9f7-de63dbe57e5b",
                "7d8298f7-00a2-448b-9811-6c7aed4817db"
                */
            };

            foreach (var userId in userIds)
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null) continue;

                foreach (var roleId in roleIds)
                {
                    var role = await roleManager.FindByIdAsync(roleId);
                    if (role == null) continue;

                    var inRole = await userManager.IsInRoleAsync(user, role.Name);
                    if (!inRole)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }
        }
    }
    public static class Seeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roleTypes = new List<string> { "Admin", "Manager", "Supervisor", "Officer" };
            var services = Enum.GetNames(typeof(Infrastructure.Domain.Consts.ServiceName));

            foreach (var service in services)
            {
                foreach (var roleType in roleTypes)
                {
                    var roleName = $"{service}-{roleType}";
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }

            var superAdminRole = "SuperAdmin";
            if (!await roleManager.RoleExistsAsync(superAdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(superAdminRole));
            }
        }
    }

}
