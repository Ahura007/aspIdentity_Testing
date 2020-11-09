using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Dotin.HostApi.IdentityDto
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public SignInResult SignInResult { get; set; }

    }
}