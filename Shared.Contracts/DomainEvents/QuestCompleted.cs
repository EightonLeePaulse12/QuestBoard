namespace Shared.Contracts.DomainEvents
{
    public record QuestCompleted(Guid Id, Guid PlayerId, int RewardXp);
}