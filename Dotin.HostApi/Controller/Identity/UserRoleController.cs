using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Identity
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