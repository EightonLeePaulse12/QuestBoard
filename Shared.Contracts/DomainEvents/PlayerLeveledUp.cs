namespace Shared.Contracts.DomainEvents
{
    public record PlayerLeveledUp
    {
        public Guid PlayerId;
        public int NewLevel;
    }
}