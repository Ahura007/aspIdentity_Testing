using System;
using System.Collections.Generic;
using Dotin.Share.Dto.Identity;

namespace Dotin.HostApi.Seed.SeedData
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