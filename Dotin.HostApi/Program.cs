using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dotin.HostApi
{
    public class Program
    {
        //https://blog.dcube.fr/index.php/2019/09/05/generic-repository-unit-of-work-et-entity-framework/
        //https://barnamenevisan.org/Articles/Article4824.html

        public static async Task Main(string[] args)
        {
            var hostManager = CreateHostBuilder(args)
                .Build();

            await hostManager.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}