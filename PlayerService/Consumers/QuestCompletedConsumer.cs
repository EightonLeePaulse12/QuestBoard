using MassTransit;
using Microsoft.EntityFrameworkCore;
using PlayerService.Infrastructure;
using Shared.Contracts.DomainEvents;

namespace PlayerService.Consumers
{
    public class QuestCompletedConsumer(PlayerDbContext _context, IPublishEndpoint _publishEndpoint) : IConsumer<QuestCompleted>
    {
        public async Task Consume(ConsumeContext<QuestCompleted> context)
        {
            var message = context.Message;

            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == message.PlayerId) ?? throw new Exception("Something went wrong");
            var previousLevel = player.Level;

            player.Xp += message.RewardXp;

            await _publishEndpoint.Publish(new XpAwarded(player.Id, message.RewardXp, message.QuestId));

            player.Level = player.Xp / 1000;

            if(player.Level > previousLevel)
            {
                await _publishEndpoint.Publish(new PlayerLeveledUp(player.Id, player.Level));
            }

            await _context.SaveChangesAsync();
        }
    }
}