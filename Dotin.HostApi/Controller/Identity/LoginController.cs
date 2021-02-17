using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Share.Dto.ApiResponse;
using Dotin.Share.Dto.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Identity
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
        public async Task<ResponseDto<LoginResultCommand>> OnPostAsync(LoginCommand loginCommand)
        {
            return await _loginService.LoginAsync(loginCommand);
        }
    }
}