using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Commands
{
    public record SendEmail(Guid PlayerId, string Title, string EmailBody);
}
