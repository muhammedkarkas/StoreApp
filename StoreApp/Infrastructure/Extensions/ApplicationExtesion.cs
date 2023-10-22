using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtesion
    {
        //Migration update işlemleri sistem çalıştırıldığında otomatik olarak yapılacaktır.
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {

            //İhtiyac duyulan servs uygulama üzerinden temin edildi.İstenseydi new lenerekte elde edilebilirdi.
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin*123";

            //UserManager
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();


            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            
            if(user is null)
            {
                user = new IdentityUser()
                {
                    Email = "adminaspnetcore@gmail.com",
                    PhoneNumber = "5555555555",
                    UserName = adminUser,
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if(!result.Succeeded)
                    throw new Exception("Admin User could not created.");

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                    );

                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for admin.");

            }

        }
    }
}
