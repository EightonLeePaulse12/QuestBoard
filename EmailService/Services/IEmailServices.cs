using Shared.Contracts.DTOs;

namespace EmailService.Services
{
    public interface IEmailServices
    {
        Task<string> SendEmailAsync(EmailStructure email);
    }
}
