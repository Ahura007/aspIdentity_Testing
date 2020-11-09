using System;
using System.Collections.Generic;

namespace Dotin.HostApi.IdentityDto
{
    public class AddUserRoleDto
    {
        public string UserId { get; set; }
        public List<string> RoleIds { get; set; }
    }
}