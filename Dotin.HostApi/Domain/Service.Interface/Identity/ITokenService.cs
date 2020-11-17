using Dotin.HostApi.Domain.Model;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}