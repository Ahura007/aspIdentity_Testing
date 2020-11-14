using System;
using System.Collections.Generic;
using Dotin.HostApi.Domain.IdentityModel;

namespace Dotin.HostApi.Db.Seed.SeedData
{
    public class RoleSeedData
    {
        public static List<ApplicationRole> CreateRole()
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