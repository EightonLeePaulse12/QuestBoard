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

            Console.WriteLine(message);

            var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == message.PlayerId);

            // Testing to see if there's data at all:
            //Console.WriteLine($"{player.Name}");

            Console.WriteLine("Consumed ID:" + message.PlayerId);
            Console.WriteLine("Actual ID:" + player.Id);

            if (player is null) throw new Exception("Something went wrong");

            var previousLevel = player.Level;

            player.Xp += message.RewardXp;

            await _publishEndpoint.Publish(new XpAwarded(player.Id, message.RewardXp));

            player.Level = player.Xp / 1000;

            if(player.Level > previousLevel)
            {
                await _publishEndpoint.Publish(new PlayerLeveledUp(player.Id, player.Level));
            }

            await _context.SaveChangesAsync();
        }
    }
}