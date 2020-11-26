using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Impl.Mapper.Identity
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