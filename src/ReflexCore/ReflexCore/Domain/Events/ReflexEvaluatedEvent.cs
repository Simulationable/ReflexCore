using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Events
{
    /// <summary>
    /// Raised when a reflex profile is evaluated and action intent is generated.
    /// </summary>
    public record ReflexEvaluatedEvent(
        Guid SessionId,
        Guid ProfileId,
        ActionIntent Intent,
        DateTimeOffset EvaluatedAt
    );
}
