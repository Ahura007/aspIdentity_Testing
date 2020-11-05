using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;

namespace Dotin.HostApi.Domain.Mapper
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