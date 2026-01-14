using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.DomainEvents
{
    public record PlayerLeveledUp
    {
        Guid PlayerId;
        int NewLevel;
    }
}
