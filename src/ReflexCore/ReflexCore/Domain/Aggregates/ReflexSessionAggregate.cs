using ReflexCore.Domain.Entities;
using ReflexCore.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Aggregates
{
    /// <summary>
    /// Aggregate root for session, trait, and audit linkage.
    /// </summary>
    public class ReflexSessionAggregate(ReflexSession session, ReflexProfile profile)
    {
        public ReflexSession Session { get; } = session ?? throw new ArgumentNullException(nameof(session));
        public ReflexProfile Profile { get; } = profile ?? throw new ArgumentNullException(nameof(profile));
        public List<AuditEvent> AuditEvents { get; } = new();

        public void RecordAudit(AuditEvent e)
        {
            AuditEvents.Add(e);
            // Raise domain event
            OnAuditLogged?.Invoke(this, new AuditLoggedEvent(e.EventId, e.UserId, e.EventType, e.Description, e.OccurredAt));
        }

        public event EventHandler<AuditLoggedEvent>? OnAuditLogged;
    }
}
