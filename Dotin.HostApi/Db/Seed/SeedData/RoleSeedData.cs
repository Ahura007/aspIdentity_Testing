using System;
using System.Collections.Generic;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;

namespace Dotin.HostApi.Db.Seed.SeedData
{
    public class RoleSeedData
    {
        public static List<ApplicationRoleDto> CreateRole()
        {
            var roles = new List<ApplicationRoleDto>
            {
                new ApplicationRoleDto
                {
                    CreateDateTime = DateTime.Now,
                    Name = "Admin",
                },
                new ApplicationRoleDto
                {
                    CreateDateTime = DateTime.Now,
                    Name = "User",
                }
            };
            return roles;
        }
    }
}