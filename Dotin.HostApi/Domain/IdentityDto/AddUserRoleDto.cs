using System.Collections.Generic;

namespace Dotin.HostApi.Domain.IdentityDto
{
    public class AddUserRoleDto
    {
        public string UserId { get; set; }
        public List<string> RoleNames { get; set; }
    }
}