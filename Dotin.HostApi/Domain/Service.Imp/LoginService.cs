using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.Helper;
using Dotin.HostApi.Domain.IdentityDto;
using Dotin.HostApi.Domain.IdentityModel;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IResponseService<LoginResultDto> _responseService;

        public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ITokenService tokenService, IResponseService<LoginResultDto> responseService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _responseService = responseService;
        }

        public async Task<ResponseDto<LoginResultDto>> LoginAsync(LoginDto loginDto)
        {
            var response = new LoginResultDto();
            response.SignInResult = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, loginDto.RememberMe, true);


            if (response.SignInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginDto.Username);
                response.AccessToken = _tokenService.GenerateJwtToken(user);
                response.ReturnUrl = "redirect home";
                return _responseService.Response(response, UserMessage.SuccessLogin);
            }

            if (response.SignInResult.RequiresTwoFactor)
            {
                response.ReturnUrl = "two factore redirect";
                return _responseService.Response(response, UserMessage.RequiresTwoFactor);
            }

            if (response.SignInResult.IsLockedOut)
            {
                response.ReturnUrl = "lock page show";
                return _responseService.Response(response, UserMessage.IsLockedOut);
            }


            response.ReturnUrl = "not allowed page ";
            return _responseService.Response(response, UserMessage.IsNotAllowed);

        }
    }
}