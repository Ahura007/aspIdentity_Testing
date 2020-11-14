using System;
using System.Linq;
using Dotin.HostApi.Db.IdentityDbContext;
using Dotin.HostApi.Db.Seed.SeedData;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotin.HostApi.Db.Seed
{
    public static class SeedService
    {

        public static IHost Seed(this IHost host)
        {
            try
            {
                using var scope = host.Services.CreateScope();
                MigrateDatabaseContext(scope.ServiceProvider);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return host;
        }

        private static void MigrateDatabaseContext(IServiceProvider serviceProvider)
        {
            var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userRoleService = serviceProvider.GetRequiredService<IUserRoleService>();

            applicationDbContext.Database.Migrate();

            var users = UserSeedData.CreateUser();
            var roles = RoleSeedData.CreateRole();

            var adminRole = new AddUserRoleDto()
            {
                UserId = users.FirstOrDefault(c => c.Id == 1)?.Id.ToString(),
                RoleNames = roles.Where(c => c.Id == 1).Select(c => c.Name).ToList()
            };
            var userRole = new AddUserRoleDto()
            {
                UserId = users.FirstOrDefault(c => c.Id == 2)?.Id.ToString(),
                RoleNames = roles.Where(c => c.Id == 2).Select(c => c.Name).ToList()
            };

            userRoleService.UserRoleAsync(adminRole);
            userRoleService.UserRoleAsync(userRole);
        }


    }
}