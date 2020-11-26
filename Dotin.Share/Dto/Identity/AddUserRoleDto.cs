using System.Collections.Generic;

namespace Dotin.Share.Dto.Identity
{
    public class AddUserRoleDto
    {
        public string UserId { get; set; }
        public List<string> RoleNames { get; set; }
    }
}