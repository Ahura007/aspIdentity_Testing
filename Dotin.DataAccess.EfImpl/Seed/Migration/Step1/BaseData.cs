﻿using System.Linq;
using System.Threading.Tasks;
using Dotin.DataAccess.EfImpl.Seed.SeedData;
using Dotin.Domain.Model.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Dotin.DataAccess.EfImpl.Seed.Migration.Step1
{
    public class BaseData
    {

    //    public static async Task Initialize(IUserRoleService userRoleService, IUserService useService, IRoleService roleService, UserManager<ApplicationUser> userManager)
    //    {
    //        var users = UserSeedData.CreateUser();
    //        var roles = RoleSeedData.CreateRole();

    //        foreach (var user in users)
    //        {
    //            await useService.CreateAsync(user, "1");
    //        }

    //        foreach (var role in roles)
    //        {
    //            await roleService.CreateAsync(role);
    //        }

    //        var adminRole = new AddUserRoleDto()
    //        {
    //            UserId = userManager.Users.FirstOrDefault(c => c.UserName == "Admin")?.Id.ToString(),
    //            RoleNames = roles.Where(c => c.Name == "Admin").Select(c => c.Name).ToList()
    //        };

    //        var userRole = new AddUserRoleDto()
    //        {
    //            UserId = userManager.Users.FirstOrDefault(c => c.UserName == "User")?.Id.ToString(),
    //            RoleNames = roles.Where(c => c.Name == "User").Select(c => c.Name).ToList()
    //        };

    //        await userRoleService.UserRoleAsync(adminRole);
    //        await userRoleService.UserRoleAsync(userRole);
    //    }
    }
}