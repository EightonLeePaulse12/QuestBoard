using MassTransit;
using Microsoft.EntityFrameworkCore;
using PlayerService.Infrastructure;
using Shared.Contracts.DomainEvents;

namespace PlayerService.Consumers
{
    public class QuestCompletedConsumer(PlayerDbContext _context) : IConsumer<QuestCompleted>
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

            player.Xp += message.RewardXp;

            if (player.Xp % 1000 == 0)
            {
                player.Level += 1;
            }

            await _context.SaveChangesAsync();
        }
    }
}