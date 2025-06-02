using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Models
{
    /// <summary>
    /// Input context for a reflex evaluation.
    /// </summary>
    public record ReflexContext(
        string SituationId,
        Emotion Emotion,
        Trait Traits,
        DateTime Timestamp
    )
    {
        public static ReflexContext Create(
            string situationId,
            Emotion emotion,
            Trait traits,
            DateTime timestamp
        )
        {
            return new ReflexContext(
                situationId,
                emotion,
                traits,
                timestamp
            );
        }
    }
}
