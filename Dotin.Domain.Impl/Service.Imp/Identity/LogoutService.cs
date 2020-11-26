using System.Threading.Tasks;
using Dotin.Domain.Interface.Service.Interface.Identity;
using Dotin.Domain.Model.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace Dotin.Domain.Impl.Service.Imp.Identity
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