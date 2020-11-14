using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;

namespace Dotin.HostApi.Domain.Service.Interface
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