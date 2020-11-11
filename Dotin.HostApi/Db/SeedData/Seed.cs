using System;
using System.Collections.Generic;
using System.Linq;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotin.HostApi.Db.SeedData
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            var users = CreateUser();
            var roles = CreateRole();

            modelBuilder.Entity<ApplicationUser>().HasData(users);
            modelBuilder.Entity<ApplicationRole>().HasData(roles);



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
         


            var services = new ServiceCollection();
            services.AddScoped<IUserRoleService>();
            var globalProvider = services.BuildServiceProvider();
            using (var scope = globalProvider.CreateScope())
            {
                var userRoleService = scope.ServiceProvider.GetService<IUserRoleService>();
                userRoleService.UserRoleAsync(adminRole);
                userRoleService.UserRoleAsync(userRole);
            }
        }




        private static List<ApplicationUser> CreateUser()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-29),
                    NationalCode = "1234567891",
                    FirstName = "Admin",
                    LastName = "Admini",
                    PhoneNumber = "+989352810284",
                    UserName = "Admin"
                },
                new ApplicationUser
                {
                    Id = 2,
                    Email = "mehdi_4294@yahoo.com",
                    BirthDate = DateTime.Now.AddYears(-35),
                    NationalCode = "1234567891",
                    FirstName = "user",
                    LastName = "useri",
                    PhoneNumber = "+989352810284",
                    UserName = "user"
                }
            };
            return users;
        }

        private static List<ApplicationRole> CreateRole()
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = 1,
                    CreateDateTime = DateTime.Now,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = 2,
                    CreateDateTime = DateTime.Now,
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            return roles;
        }
    }


 
}