using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;
using Dotin.HostApi.Domain.Model;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface IRoleService
    {
        Task<ResponseDto<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto roleDto);
        Task<bool> IsExistsAsync(ApplicationRoleDto roleDto);
        Task<ResponseDto<ApplicationRoleDto>> GetAllAsync();
        Task<ResponseDto<ApplicationRoleDto>> GetByIdAsync(int id);
        Task<List<ApplicationRole>> GetByNameAsync(List<string> names);
    }
}