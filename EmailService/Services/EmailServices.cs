using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Shared.Contracts.DTOs;

namespace EmailService.Services
{
    public class EmailServices : IEmailServices
    {
        public async Task<string> SendEmailAsync(EmailStructure email)
        {
            var _email = new MimeMessage();
            _email.From.Add(new MailboxAddress("QuestBoard", "questboard@demoasync.com"));
            _email.To.Add(new MailboxAddress("Eighton-Lee", "eightonleepaulse@gmail.com"));
            _email.Subject = email.Title;
            _email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Content };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("lucy.mcglynn97@ethereal.email", "Yxg5NwsxyP4Ewt5NTJ", CancellationToken.None);
            smtp.Send(_email);
            smtp.Disconnect(true);
            return "Email sent";
        }
    }
}
