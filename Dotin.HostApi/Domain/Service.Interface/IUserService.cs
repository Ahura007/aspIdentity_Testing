using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IUserService
    {
        Task<ResponseDto<ApplicationUserDto>> CreateAsync(ApplicationUserDto roleDto);
        Task<List<ApplicationUserDto>> GetAllAsync();
    }
}