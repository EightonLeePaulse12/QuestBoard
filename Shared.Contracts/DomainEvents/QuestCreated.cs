namespace Shared.Contracts.DomainEvents
{
    public record QuestCreated
    {
        public Guid QuestId;
        public Guid PlayerId;
        public string Title;
    }
}