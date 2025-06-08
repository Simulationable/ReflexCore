using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Commands
{
    public class AuditEventCommand(Guid eventId, Guid profileId, string eventType, string description, DateTimeOffset occurredAt)
    {
        public Guid EventId { get; } = eventId;
        public Guid ProfileId { get; } = profileId;
        public string EventType { get; } = eventType;
        public string Description { get; } = description;
        public DateTimeOffset OccurredAt { get; } = occurredAt;
    }
}
