using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IRoleService
    {
        Task<ResponseDto<ApplicationRoleCommand>> CreateAsync(ApplicationRoleCommand roleCommand);
        Task<bool> IsExistsAsync(ApplicationRoleCommand roleCommand);
        Task<ResponseDto<ApplicationRoleCommand>> GetAllAsync();
        Task<ResponseDto<ApplicationRoleCommand>> GetByIdAsync(int id);
        Task<List<ApplicationRoleCommand>> GetByNameAsync(List<string> names);
    }
}