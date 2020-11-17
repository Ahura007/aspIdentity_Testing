using System.Threading.Tasks;
using Dotin.HostApi.Domain.Model;
using Dotin.HostApi.Domain.Service.Interface.Identity;
using Microsoft.AspNetCore.Identity;

namespace Dotin.HostApi.Domain.Service.Imp.Identity
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LogoutService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}