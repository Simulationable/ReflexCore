using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents an audit event in the Reflex system.
    /// </summary>
    public class AuditEvent(Guid eventId, string userId, AuditEventType eventType, string description, DateTimeOffset occurredAt, string? targetId = null)
    {
        public Guid EventId { get; } = eventId;
        public string UserId { get; } = userId ?? throw new ArgumentNullException(nameof(userId));
        public AuditEventType EventType { get; } = eventType;
        public string? TargetId { get; } = targetId;
        public string Description { get; } = description ?? throw new ArgumentNullException(nameof(description));
        public DateTimeOffset OccurredAt { get; } = occurredAt;
    }
}
