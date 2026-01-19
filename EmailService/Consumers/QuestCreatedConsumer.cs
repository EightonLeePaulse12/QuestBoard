using EmailService.Services;
using MassTransit;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.DTOs;

namespace EmailService.Consumers
{
    public class QuestCreatedConsumer(IEmailServices _emailServices) : IConsumer<QuestCreated>
    {
        public async Task Consume(ConsumeContext<QuestCreated> context)
        {
            EmailStructure email = new EmailStructure(
                Title: "Quest Created 🎉",
                Content: $"Quest '{context.Message.Title}' created!"
            );

            await _emailServices.SendEmailAsync(email);
        }
    }
}
