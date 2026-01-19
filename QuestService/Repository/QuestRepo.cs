using MassTransit;
using Microsoft.EntityFrameworkCore;
using QuestService.Domain;
using QuestService.Infrastructure;
using Shared.Contracts.DomainEvents;
using Shared.Contracts.DTOs;

namespace QuestService.Repository
{
    public class QuestRepo(QuestDbContext context, IPublishEndpoint publishEndpoint) : IQuestRepo
    {
        public async Task<List<Quest>?> GetAllQuestsByPlayerIdAsync(Guid playerId)
        {
            var quests = await context.Quests.Where(x => x.PlayerId == playerId).ToListAsync();

            if (quests is not null)
            {
                return quests;
            }
            else
            {
                throw new Exception("No quests for this user was found");
            }
        }

        public async Task<ServiceResponse> AddQuestAsync(Quest quest)
        {
            if (quest.PlayerId == Guid.Empty) throw new Exception("PlayerId cannot be empty");

            context.Quests.Add(quest);
            await context.SaveChangesAsync();

            await publishEndpoint.Publish(new QuestCreated(
                quest.Id,
                quest.PlayerId,
                quest.Title
            ));

            return new ServiceResponse(true, "Quest Created Successfully");
        }

        public async Task<ServiceResponse> MarkQuestCompletedAsync(Guid questId)
        {
            var quest = await context.Quests.FirstOrDefaultAsync(x => x.Id == questId);

            Console.WriteLine("Checking if quest fetched properly: " + quest.Id);

            if (quest is null || questId == null || questId == Guid.Empty)
            {
                throw new Exception("This quest does not exist");
            }
            else
            {
                quest.IsCompleted = true;
            }

            await context.SaveChangesAsync();

            await publishEndpoint.Publish(new QuestCompleted(
                quest.Id,
                quest.PlayerId,
                quest.RewardXp
            ));

            await publishEndpoint.Publish(new XpAwarded(quest.PlayerId, quest.RewardXp));

            return new ServiceResponse(true, "Quest marked as completed successfully");
        }
    }
}