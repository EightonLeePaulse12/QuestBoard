using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Sagas
{
    public record SendLevelUpEmail(Guid PlayerId, int Level);
}
