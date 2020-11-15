using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IUserService
    {
        Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto roleDto, string password);
        Task<ResponseDto<ApplicationUserDto>> GetAllAsync();
    }
}