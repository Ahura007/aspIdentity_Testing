using System.Threading.Tasks;
using Dotin.HostApi.Domain.Service.Interface;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Dotin.HostApi.Domain.Service.Imp
{
    public class EmailService: IEmailService
    {
        private readonly EmailSenderOptions _options;
        public EmailService(IOptions<EmailSenderOptions> options)
        {
            _options = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sendGridOptions = new SendGridClientOptions
            {
                ApiKey = _options.ApiKey
            };
            var emailClient = new SendGridClient(sendGridOptions);
            var message = new SendGridMessage
            {
                From = new EmailAddress("authentication@sample.com"),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);

            return emailClient.SendEmailAsync(message);
        }
    }

    public class EmailSenderOptions
    {
        public string ApiKey { get; set; }
    }
}