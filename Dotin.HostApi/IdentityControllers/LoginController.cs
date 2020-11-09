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

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(LoginDto loginDto, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var loginResponse = await _loginService.Login(loginDto);


                if (loginResponse.Result.SignInResult.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                if (loginResponse.Result.SignInResult.RequiresTwoFactor)
                {
                    return Redirect("two factor page");
                }

                if (loginResponse.Result.SignInResult.IsLockedOut)
                {
                    return BadRequest();
                }

                if (loginResponse.Result.SignInResult.IsNotAllowed)
                {
                    return BadRequest();
                }

            }
            return BadRequest();

        }
    }
}