using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.DomainEvents
{
    public record QuestCreated
    {
        Guid QuestId;
        Guid PlayerId;
        string Title;
    }
}
