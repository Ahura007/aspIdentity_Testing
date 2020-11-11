using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Dotin.HostApi.Domain.IdentityDto
{
    public class LoginResultDto
    {
        public string AccessToken { get; set; }
        public SignInResult SignInResult { get; set; }
        public string ReturnUrl { get; set; }

  

    }
}