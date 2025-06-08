using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Events
{
    /// <summary>
    /// Raised when consent is given or revoked.
    /// </summary>
    public record ConsentGivenEvent(
        string UserId,
        ConsentType ConsentType,
        bool IsGranted,
        DateTimeOffset Timestamp
    );
}
