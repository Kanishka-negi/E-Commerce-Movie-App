using Microsoft.AspNetCore.Identity;
using Movie_Web_Mvc.Models;

namespace Movie_Web_Mvc.Models
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema {
                            Name = "PVR",
                            Logo = "https://www.musafirnamah.com/wp-content/uploads/2015/07/pvr-logo.jpg",
                            Description = "This is the description of the first cinema"
                        }
                        
                    
                    });
                   
                   
                context.SaveChanges();
                }


                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                {
                    new Movie()
                    {
                        Name = "The Kerala Files",
                        Description="Dom Toretto and his family must confront a terrifying new enemy who`s fueled by revenge.",
                        Price = 250,
                        Logo = "https://upload.wikimedia.org/wikipedia/en/d/d0/The_Kerala_Story_poster.jpg",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(3),
                        CinemaId = 1,
                        MovieCategory ="Drama"
                    },

                     new Movie()
                     {
                         Name = "Guardians of the Galaxy",
                         Description="A spine-chilling, never told before true story - revealing a dangerous conspiracy that has been hatched against India",

                        Price = 250,
                        Logo = "https://assets-in.bmscdn.com/iedb/Movies/images/mobile/thumbnail/xlarge/guardians-of-the-galaxy-vol-3-et00310794-1683529214.jpg",
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(10),
                        CinemaId = 1,
                        MovieCategory ="Adventure"
                    },
                   

                });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "User@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Hello@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Hello@1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
                
