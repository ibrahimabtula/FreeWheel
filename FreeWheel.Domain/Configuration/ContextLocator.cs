using FreeWheel.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StructureMap;

namespace FreeWheel.Domain.Configuration
{
    public static class ContextLocator
    {
        private static DbContextOptionsBuilder<ApplicationDbContext> Options;
        private static Container Container;
        private static IConfigurationRoot _configurationRoot;

        public static void Initialise(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
            string connString = _configurationRoot.GetConnectionString("ApplicationConnectionString");
            Options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connString);

            Container = new Container(configuration =>
            {
                configuration.For<ApplicationDbContext>()
                    .Use<ApplicationDbContext>(() => new ApplicationDbContext(Options.Options))
                    .Transient();
            });
        }

        public static ApplicationDbContext GetContext()
        {
            return Container.GetInstance<ApplicationDbContext>();
        }
    }
}
