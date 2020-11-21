using Dotin.HostApi.Domain.Model;
using Dotin.HostApi.Domain.Model.Identity;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}