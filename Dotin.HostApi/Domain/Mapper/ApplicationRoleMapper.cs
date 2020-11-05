using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;

namespace Dotin.HostApi.Domain.Mapper
{
    public class ApplicationRoleMapper : AutoMapper.Profile
    {
        public ApplicationRoleMapper()
        {
            CreateMap<ApplicationRole, ApplicationRoleDto>();
            CreateMap<ApplicationRoleDto, ApplicationRole>();
        }
    }
}