using Dotin.HostApi.IdentityModel;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}