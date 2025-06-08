using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents an active or historical reflex session.
    /// </summary>
    public class ReflexSession(Guid sessionId, string userId, Guid profileId, DateTimeOffset startedAt)
    {
        public Guid SessionId { get; } = sessionId;
        public string UserId { get; } = userId ?? throw new ArgumentNullException(nameof(userId));
        public Guid ProfileId { get; } = profileId;
        public DateTimeOffset StartedAt { get; } = startedAt;
        public DateTimeOffset? EndedAt { get; private set; }
        public bool IsActive => !EndedAt.HasValue;
        public List<Guid> ActionsTaken { get; } = new();

        public void EndSession(DateTimeOffset? endedAt = null)
        {
            EndedAt = endedAt ?? DateTimeOffset.UtcNow;
        }

        public void LogAction(Guid actionId)
        {
            if (!ActionsTaken.Contains(actionId))
                ActionsTaken.Add(actionId);
        }
    }
}
