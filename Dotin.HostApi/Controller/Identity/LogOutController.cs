using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Controller.Identity
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