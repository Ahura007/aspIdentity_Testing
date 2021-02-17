using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IUserRoleService
    {
        Task<ResponseDto<ApplicationUserCommand>> UserRoleAsync(AddUserRoleCommand userRole);
    }
}