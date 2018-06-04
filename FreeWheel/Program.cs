using FreeWheel.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FreeWheel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .Initialise()
                .Seed()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
