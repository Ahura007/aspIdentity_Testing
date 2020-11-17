using System.Threading.Tasks;
using Dotin.HostApi.Domain.Dto.Identity;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.Domain.Service.Interface.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.IdentityControllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ResponseDto<LoginResultDto>> OnPostAsync(LoginDto loginDto)
        {
            return await _loginService.LoginAsync(loginDto);
        }
    }
}