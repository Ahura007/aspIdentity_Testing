using System.Threading.Tasks;

namespace Dotin.HostApi.Domain.Service.Interface.Identity
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
