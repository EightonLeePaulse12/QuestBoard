using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Commands
{
    public record AwardXp(Guid PlayerId, int Amount);
}
