using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents a log entry of a trait change for audit/history.
    /// </summary>
    public class TraitChangeLog
    {
        public Guid LogId { get; }
        public Guid ProfileId { get; }
        public string TraitName { get; }
        public float OldValue { get; }
        public float NewValue { get; }
        public DateTimeOffset ChangedAt { get; }
        public string ChangedBy { get; }

        public TraitChangeLog(Guid logId, Guid profileId, string traitName, float oldValue, float newValue, DateTimeOffset changedAt, string changedBy)
        {
            LogId = logId;
            ProfileId = profileId;
            TraitName = traitName;
            OldValue = oldValue;
            NewValue = newValue;
            ChangedAt = changedAt;
            ChangedBy = changedBy;
        }
    }
}
