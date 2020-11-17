using System.Threading.Tasks;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface ILogoutService
    {
        Task LogoutAsync();
    }
}