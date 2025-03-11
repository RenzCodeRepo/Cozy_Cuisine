using Microsoft.AspNetCore.Identity;

namespace Cozy_Cuisine.Data
{
    public class DbInitializer
    {
        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Define roles to be seeded
                var roles = new List<string> {"Admin"};

                // Ensure all roles exist
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // Define users to be seeded
                var users = new List<(string Email, string Password, string Role)>
            {
                ("renzbaladjay25@gmail.com", "StrongPassword123!", "Admin"),
                ("davidkhateleenjoyce@gmail.com", "StrongPassword123!", "Admin"),
                ("joanffbalaca@gmail.com", "StrongPassword123!", "Admin"),
                ("ma.velaxco@gmail.com", "StrongPassword123!", "Admin"),
                ("cornelia.joshua@gmail.com", "StrongPassword123!", "Admin"),
                ("alyssajhaneburce@gmail.com", "StrongPassword123!", "Admin")
            };

                // Seed users
                foreach (var (email, password, role) in users)
                {
                    if (await userManager.FindByEmailAsync(email) == null)
                    {
                        var user = new IdentityUser
                        {
                            UserName = email,
                            Email = email,
                            EmailConfirmed = true
                        };

                        var result = await userManager.CreateAsync(user, password);
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }
            }
        }
    }
}
