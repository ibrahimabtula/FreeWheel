using FreeWheel.Infrastructure.Context;
using FreeWheel.Infrastructure.Extrentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FreeWheel.Extensions
{
    public static class WebHostExtensions
    {

        public static IWebHost Initialise(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    dbContext.Database.Migrate();
                }
            }
            return webhost;
        }

        public static IWebHost Seed(this IWebHost webhost)
        {
            using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    dbContext.EnsureSeedData();
                }
            }
            return webhost;
        }
    }
}
