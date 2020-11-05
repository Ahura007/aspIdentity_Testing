using System.Threading.Tasks;

namespace Dotin.HostApi.Domain.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
