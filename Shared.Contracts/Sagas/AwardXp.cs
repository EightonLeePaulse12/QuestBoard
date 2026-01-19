using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Sagas
{
    public record AwardXp(Guid PlayerId, int Amount);
}
