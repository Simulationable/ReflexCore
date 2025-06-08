using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Enums
{
    /// <summary>
    /// All possible AI or user actions in the reflex engine.
    /// </summary>
    public enum ReflexAction
    {
        None,
        Greet,
        Warn,
        Encourage,
        Escalate,
        AlertModerator,
        LogOnly,
        SuggestRest,
        RecommendHelp,
        EndSession,
        StayWithUser,
        OfferSupport
    }
}
