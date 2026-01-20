namespace Shared.Contracts.DomainEvents
{
    public record XpAwarded(Guid PlayerId, int Amount, Guid QuestId);
}