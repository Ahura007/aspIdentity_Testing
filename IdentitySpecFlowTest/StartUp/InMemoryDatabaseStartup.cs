using System.Linq;
using Dotin.HostApi.DataAccess.Db.IdentityDbContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentitySpecFlowTest.StartUp
{
    public class InMemoryDatabaseStartup<T> : WebApplicationFactory<T> where T : class
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
                var removeDbContext =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (removeDbContext != null)
                    services.Remove(removeDbContext);

                services.AddDbContextPool<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                }, 256);

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