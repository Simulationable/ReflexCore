using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Models
{
    /// <summary>
    /// Output packet (result of reflex evaluation).
    /// </summary>
    public record ReflexPacket(
        ActionIntent Intent,
        DateTime EvaluatedAt
    )
    {
        public static ReflexPacket Create(
        ActionIntent intent,
        DateTime evaluatedAt
        )
        {
            return new ReflexPacket(
                intent,
                evaluatedAt
            );
        }
    }
}
