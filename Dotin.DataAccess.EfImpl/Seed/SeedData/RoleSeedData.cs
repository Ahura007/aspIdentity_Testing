using System;
using System.Collections.Generic;
using Dotin.Domain.Model.Model.Identity;

namespace Dotin.DataAccess.EfImpl.Seed.SeedData
{
    public class RoleSeedData
    {
        public static List<ApplicationRole> CreateRole()
        {
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    CreateDateTime = DateTime.Now,
                    Name = "Admin",
                },
                new ApplicationRole
                {
                    CreateDateTime = DateTime.Now,
                    Name = "User",
                }
            };
            return roles;
        }
    }
}