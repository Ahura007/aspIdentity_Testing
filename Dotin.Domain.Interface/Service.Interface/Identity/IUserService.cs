using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IUserService
    {
        Task<ResponseDto<ApplicationUserCommand>> CreateAsync(ApplicationUserCommand roleCommand, string password);
        Task<ResponseDto<ApplicationUserCommand>> GetAllAsync();
    }
}