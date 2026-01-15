namespace Shared.Contracts.DomainEvents
{
    public class OutboxMessage
    {
        public Guid Id;
        public string Type;
        public string Payload;
        public DateTime CreatedAt;
        public bool Processed;
    }
}