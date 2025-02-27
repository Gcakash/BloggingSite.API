using BloggingSite.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BloggingSite.API.Data
{
    public static class DefaultSeedData
    {
            public static async Task Initialize(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Seed roles
                string[] roleNames = { "Admin", "User" };
                foreach (var roleName in roleNames)
                {
                    var roleExists = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                // Seed default admin account
                var adminEmail = "akashgcsky58@gmail.com";
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                if (adminUser == null)
                {
                    var admin = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        FirstName = "Admin",
                        LastName = "User",
                        ProfilePicture = "",
                        DateOfBirth = new DateTime(1990, 1, 1),
                        Bio = "I am the admin of this site."
                    };

                    var result = await userManager.CreateAsync(admin, "Admin@123");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }
            }
        }
    }
