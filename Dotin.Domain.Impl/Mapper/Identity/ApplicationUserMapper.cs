using Dotin.Domain.Model.Model.Identity;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Impl.Mapper.Identity
{
    public class ApplicationUserMapper : AutoMapper.Profile
    {
        public ApplicationUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserCommand>();
            CreateMap<ApplicationUserCommand, ApplicationUser>();
        }
    }


   


}