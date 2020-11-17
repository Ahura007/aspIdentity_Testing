using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface IUserService
    {
        Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto roleDto, string password);
        Task<ResponseDto<ApplicationUserDto>> GetAllAsync();
    }
}