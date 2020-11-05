using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.IdentityDto;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IRoleService
    {
        Task<ApplicationRoleDto> CreateAsync(ApplicationRoleDto roleDto);
        Task<bool> IsExists(ApplicationRoleDto roleDto);
        Task<List<ApplicationRoleDto>> GetAll();
        Task<ApplicationRoleDto> GetById(int id);
    }
}