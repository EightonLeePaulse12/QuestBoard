using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.DomainEvents
{
    public class OutboxMessage
    {
        Guid Id;
        string Type;
        string Payload;
        DateTime CreatedAt;
        bool Processed;
    }
}
