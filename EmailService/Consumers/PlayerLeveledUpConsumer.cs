using EmailService.Services;
using MassTransit;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.DTOs;

namespace EmailService.Consumers
{
    public class PlayerLeveledUpConsumer(IEmailServices _emailServices) : IConsumer<PlayerLeveledUp>
    {
        public async Task Consume(ConsumeContext<PlayerLeveledUp> context)
        {
            Console.WriteLine(context.Message.NewLevel);
            Console.WriteLine(context.Message.PlayerId);

            EmailStructure email = new EmailStructure(
                Title: "Leveled up! 🎉",
                Content: $"You're now level {context.Message.NewLevel}!"
            );

            await _emailServices.SendEmailAsync(email);
        }
    }
}
