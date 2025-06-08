using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Events
{
    /// <summary>
    /// Raised when an audit event is logged.
    /// </summary>
    public record AuditLoggedEvent(
        Guid EventId,
        string UserId,
        AuditEventType EventType,
        string Description,
        DateTimeOffset OccurredAt
    );
}
