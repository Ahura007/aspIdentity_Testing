using System.Threading.Tasks;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.IdentityControllers
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
            await _logoutService.LogoutAsync();
            if (returnUrl != null)
                return LocalRedirect(returnUrl);
            return LocalRedirect("~/");
        }
    }
}