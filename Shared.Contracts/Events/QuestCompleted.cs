namespace Shared.Contracts.DomainEvents
{
    public record QuestCompleted(Guid QuestId, Guid PlayerId, int RewardXp);
}