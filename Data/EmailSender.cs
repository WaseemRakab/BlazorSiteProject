using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace WaseemRkab_Portfolio.Data
{
    public class EmailSender
    {
        private readonly EmailSettings emailSettings;

        public EmailSender(IOptions<EmailSettings> optionsAccessor)
        {
            emailSettings = optionsAccessor.Value;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(emailSettings.SenderName, emailSettings.Sender));
                mail.To.Add(new MailboxAddress(email));
                mail.Subject = subject;
                mail.Body = new TextPart(TextFormat.Html) { Text = message };
                using var client = new SmtpClient
                {
                    ServerCertificateValidationCallback = (s, c, h, e) => true
                };
                await client.ConnectAsync(emailSettings.MailServer, emailSettings.MailPort);
                if (client.IsConnected)
                {
                    await client.AuthenticateAsync(emailSettings.Sender, emailSettings.Password);
                    if (client.IsAuthenticated)
                    {
                        await client.SendAsync(mail);
                        return true;
                    }
                }
            }
            catch { return false; }
            return false;
        }
    }
}