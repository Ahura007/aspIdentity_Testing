using System.Linq;
using Dotin.DataAccess.EfImpl.Db.DbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityUnitTest.StartUp
{
    public class RealDatabaseStartup<T> : WebApplicationFactory<T> where T : class
    {
        public IHost HostWeb { get; set; }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            HostWeb = builder.Build();
            HostWeb.Start();
            return HostWeb;
        }


        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            {
                var path = hostingContext.HostingEnvironment.ContentRootPath;
                configurationBuilder.AddJsonFile($"{path}\\appsettings.json", true, true);
                configurationBuilder.AddEnvironmentVariables();
            });

            builder.ConfigureServices(services =>
            {
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                    db.Database.EnsureCreated();
                }
            });
        }
    }
}