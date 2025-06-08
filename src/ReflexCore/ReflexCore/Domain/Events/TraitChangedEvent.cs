using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Events
{
    /// <summary>
    /// Raised when a trait value has changed.
    /// </summary>
    public record TraitChangedEvent(
        Guid ProfileId,
        Trait OldTraits,
        Trait NewTraits,
        DateTimeOffset ChangedAt
    );
}
