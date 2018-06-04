
using FreeWheel.Domain.Configuration;
using FreeWheel.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreeWheel
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            ConfigurationRoot = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                    .AddEnvironmentVariables()
                    .Build();

            ContextLocator.Initialise(ConfigurationRoot);
        }

        public IConfiguration Configuration { get; }

        public IConfigurationRoot ConfigurationRoot { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connStr = ConfigurationRoot.GetConnectionString("ApplicationConnectionString");

            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connStr));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
