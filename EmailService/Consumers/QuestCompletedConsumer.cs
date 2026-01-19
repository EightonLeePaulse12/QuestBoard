using EmailService.Services;
using MassTransit;
using Microsoft.AspNetCore.Identity.UI.Services;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.DTOs;

namespace EmailService.Consumers
{
    public class QuestCompletedConsumer(IEmailServices _emailServices) : IConsumer<QuestCompleted>
    {
        public async Task Consume(ConsumeContext<QuestCompleted> context)
        {
            EmailStructure email = new EmailStructure(
                Title: "Quest Completed 🎉",
                Content: $"You've completed a quest and earned {context.Message.RewardXp} XP"
            );

            await _emailServices.SendEmailAsync(email);
        }
    }
}
