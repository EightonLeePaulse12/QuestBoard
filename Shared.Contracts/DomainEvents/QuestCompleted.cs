using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.DomainEvents
{
    public record QuestCompleted
    {
        Guid QuestId;
        Guid PlayerId;
        int XpReward;
    }
}
