using System.Collections.Generic;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.IdentityControllers
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
        public async Task<List<ApplicationRoleDto>> GetAllAsync()
        {
            return await _roleService.GetAll();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(ApplicationRoleDto role)
        {
            if (ModelState.IsValid)
            {
                await _roleService.CreateAsync(role);
                return Ok();
            }

            return BadRequest();
        }
    }
}

