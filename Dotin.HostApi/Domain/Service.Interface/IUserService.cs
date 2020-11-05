using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IUserService
    {
        Task<bool> CreateAsync(ApplicationUserDto roleDto);
        Task<List<ApplicationUserDto>> GetAll();
    }
}