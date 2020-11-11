using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;

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