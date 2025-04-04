using Cozy_Cuisine.Data.IServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace Cozy_Cuisine.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
     
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Your Website", _configuration["EmailSettings:From"]));
                email.To.Add(new MailboxAddress("", to));
                email.Subject = subject;

                var bodyBuilder = new BodyBuilder { TextBody = body };
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_configuration["EmailSettings:SmtpServer"],
                             int.Parse(_configuration["EmailSettings:Port"]),
                             MailKit.Security.SecureSocketOptions.StartTls); // ✅ Use StartTls

                await smtp.AuthenticateAsync(_configuration["EmailSettings:Username"],
                                             _configuration["EmailSettings:Password"]);

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                _logger.LogInformation($"✅ Email sent successfully to {to}");
            }
            catch (SmtpCommandException ex)
            {
                _logger.LogError($"❌ SMTP Command Error: {ex.StatusCode} - {ex.Message}");
            }
            catch (SmtpProtocolException ex)
            {
                _logger.LogError($"❌ SMTP Protocol Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ General Error: {ex.Message}");
            }
        }


    }
}
