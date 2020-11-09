using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.IdentityControllers
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