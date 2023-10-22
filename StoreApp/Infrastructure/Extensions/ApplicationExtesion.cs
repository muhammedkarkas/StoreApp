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
    }
}
