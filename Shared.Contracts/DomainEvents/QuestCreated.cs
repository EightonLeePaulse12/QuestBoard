namespace Shared.Contracts.DomainEvents
{
    public record QuestCreated(Guid QuestId, Guid PlayerId, string Title);
}