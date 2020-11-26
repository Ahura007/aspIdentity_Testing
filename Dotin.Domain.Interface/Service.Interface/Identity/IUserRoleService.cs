using System.Threading.Tasks;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IUserRoleService
    {
        Task<ResponseDto<ApplicationUserDto>> UserRoleAsync(AddUserRoleDto userRole);
    }
}