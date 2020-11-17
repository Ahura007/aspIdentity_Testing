using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.Domain.Service.Interface.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.IdentityControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        [HttpPost]
        public async Task<ResponseDto<ApplicationUserDto>> OnPostAsync(AddUserRoleDto model)
        {
            return await _userRoleService.UserRoleAsync(model);
        }


    }
}