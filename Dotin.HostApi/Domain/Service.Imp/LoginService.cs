using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Dotin.HostApi.Helper;
using Dotin.HostApi.IdentityDto;
using Dotin.HostApi.IdentityModel;
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
                response.Token = _tokenService.GenerateJwtToken(user);
            }
            return _responseService.Build(response, new List<IdentityError>(), new OkResult(), UserMessage.SuccessLogin);
        }
    }
}