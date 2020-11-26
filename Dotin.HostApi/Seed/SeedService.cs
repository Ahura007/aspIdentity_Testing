using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotin.HostApi.Seed
{
    public static class SeedService
    {
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    await MigrateDatabaseContext(scope.ServiceProvider);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return host;
        }

        private static async Task MigrateDatabaseContext(IServiceProvider serviceProvider)
        {
            //var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //var userRoleService = serviceProvider.GetRequiredService<IUserRoleService>();
            //var useService = serviceProvider.GetRequiredService<IUserService>();
            //var roleService = serviceProvider.GetRequiredService<IRoleService>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();



            //await BaseData.Initialize(userRoleService, useService, roleService, userManager);

            //await applicationDbContext.Database.MigrateAsync();


        }


    }
}