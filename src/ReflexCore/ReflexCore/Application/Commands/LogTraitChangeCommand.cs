using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Commands
{
    public class LogTraitChangeCommand(Guid profileId, Trait oldTrait, Trait newTrait, DateTimeOffset changedAt)
    {
        public Guid ProfileId { get; } = profileId;
        public Trait OldTrait { get; } = oldTrait;
        public Trait NewTrait { get; } = newTrait;
        public DateTimeOffset ChangedAt { get; } = changedAt;
    }
}
