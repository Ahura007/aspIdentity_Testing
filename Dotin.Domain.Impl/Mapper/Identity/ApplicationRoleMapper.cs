using Dotin.HostApi.Domain.Dto.Identity;
using Dotin.HostApi.Domain.Model;
using Dotin.HostApi.Domain.Model.Identity;

namespace Dotin.HostApi.Domain.Mapper.Identity
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