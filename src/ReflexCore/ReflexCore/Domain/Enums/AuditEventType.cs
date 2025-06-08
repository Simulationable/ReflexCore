using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Enums
{
    /// <summary>
    /// Audit event category (GDPR, PDPA, admin, etc.)
    /// </summary>
    public enum AuditEventType
    {
        Login,
        Logout,
        TraitChanged,
        ConsentGiven,
        SessionStarted,
        SessionEnded,
        ActionTaken,
        AlertRaised,
        AdminOverride,
        Other
    }
}
