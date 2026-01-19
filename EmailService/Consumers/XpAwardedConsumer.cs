using EmailService.Services;
using MassTransit;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.DTOs;

namespace EmailService.Consumers
{
    public class XpAwardedConsumer(IEmailServices _emailServices) : IConsumer<XpAwarded>
    {
        public async Task Consume(ConsumeContext<XpAwarded> context)
        {
            EmailStructure email = new EmailStructure(
                Title: "Xp Gained 🎉",
                Content: $"You earned {context.Message.Amount} XP!"
            );

            await _emailServices.SendEmailAsync(email);
        }
    }
}
