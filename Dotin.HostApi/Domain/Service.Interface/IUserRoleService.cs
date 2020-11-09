using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IUserRoleService
    {
        Task<ResponseDto<ApplicationUserDto>> UserRoleAsync(AddUserRoleDto userRole);
    }
}