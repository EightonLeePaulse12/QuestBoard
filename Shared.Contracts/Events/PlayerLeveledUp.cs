namespace Shared.Contracts.DomainEvents
{
    public record PlayerLeveledUp(Guid PlayerId, int NewLevel);
}