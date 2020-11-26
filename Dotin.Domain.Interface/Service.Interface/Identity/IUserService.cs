using System.Threading.Tasks;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IUserService
    {
        Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto roleDto, string password);
        Task<ResponseDto<ApplicationUserDto>> GetAllAsync();
    }
}