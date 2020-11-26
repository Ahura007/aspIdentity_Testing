using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IRoleService
    {
        Task<ResponseDto<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto roleDto);
        Task<bool> IsExistsAsync(ApplicationRoleDto roleDto);
        Task<ResponseDto<ApplicationRoleDto>> GetAllAsync();
        Task<ResponseDto<ApplicationRoleDto>> GetByIdAsync(int id);
        Task<List<ApplicationRoleDto>> GetByNameAsync(List<string> names);
    }
}