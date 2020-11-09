using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Dotin.HostApi.IdentityControllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class LogOutController : ControllerBase
    {
        private readonly ILogoutService _logoutService;

        public LogOutController(ILogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(LoginDto loginDto, string returnUrl)
        {
            await _logoutService.Logout();
            if (returnUrl != null)
                return LocalRedirect(returnUrl);
            return LocalRedirect("~/");
        }
    }
}