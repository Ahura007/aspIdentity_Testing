using Dotin.HostApi.Domain.Dto.Identity;
using Dotin.HostApi.Domain.Model;

namespace Dotin.HostApi.Domain.Mapper.Identity
{
    public class ApplicationUserMapper : AutoMapper.Profile
    {
        public ApplicationUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>();
        }
    }


   


}