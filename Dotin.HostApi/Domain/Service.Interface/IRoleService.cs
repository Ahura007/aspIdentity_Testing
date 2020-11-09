using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IRoleService
    {
        Task<ResponseDto<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto roleDto);
        Task<bool> IsExistsAsync(ApplicationRoleDto roleDto);
        Task<List<ApplicationRoleDto>> GetAllAsync();
        Task<ApplicationRoleDto> GetByIdAsync(int id);
    }
}