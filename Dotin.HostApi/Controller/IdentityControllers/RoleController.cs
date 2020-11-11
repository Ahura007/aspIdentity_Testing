using System.Threading.Tasks;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.IdentityControllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ResponseDto<ApplicationRoleDto>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }


        [HttpPost]
        public async Task<ResponseDto<ApplicationRoleDto>> CreateAsync(ApplicationRoleDto role)
        {
            return await _roleService.CreateAsync(role);
        }
    }
}

