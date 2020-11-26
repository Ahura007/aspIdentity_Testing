using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotin.HostApi.DataAccess.Db.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dotin.HostApi
{
    public class Program
    {
        //https://blog.dcube.fr/index.php/2019/09/05/generic-repository-unit-of-work-et-entity-framework/
        //https://barnamenevisan.org/Articles/Article4824.html


        public static IHost HostManager { get; set; }
        public static async Task Main(string[] args)
        {
            HostManager = await CreateHostBuilder(args)
                      .Build()
                      .SeedAsync();

            await HostManager.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(configure: webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });






    }
}
