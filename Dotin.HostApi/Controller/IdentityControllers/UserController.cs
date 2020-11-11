using System.Threading.Tasks;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.IdentityControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ResponseDto<ApplicationUserDto>> OnPostAsync(ApplicationUserDto model)
        {
            return await _userService.CreateAsync(model);
        }


        [HttpGet]
        public async Task<ResponseDto<ApplicationUserDto>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }
    }




}
