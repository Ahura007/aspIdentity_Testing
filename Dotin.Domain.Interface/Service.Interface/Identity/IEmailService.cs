using System.Threading.Tasks;

namespace Dotin.Domain.Interface.Service.Interface.Identity
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
