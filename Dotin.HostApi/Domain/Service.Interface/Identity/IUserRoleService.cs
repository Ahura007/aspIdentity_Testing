using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface IUserRoleService
    {
        Task<ResponseDto<ApplicationUserDto>> UserRoleAsync(AddUserRoleDto userRole);
    }
}