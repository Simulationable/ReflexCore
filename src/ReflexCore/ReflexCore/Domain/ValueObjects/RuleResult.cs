using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.ValueObjects
{
    /// <summary>
    /// Intermediate rule output (before action generation).
    /// </summary>
    public record RuleResult(
        ReflexAction Action,
        float Confidence,
        string Explanation
    )
    {
        public static RuleResult Create(ReflexAction action, float confidence, string explanation)
        {
            if (confidence < 0f || confidence > 1f)
                throw new ArgumentOutOfRangeException(nameof(confidence), "Confidence must be in [0,1].");
            if (string.IsNullOrWhiteSpace(explanation))
                throw new ArgumentException("Explanation cannot be null or empty.", nameof(explanation));
            return new RuleResult(action, confidence, explanation);
        }
    }
}
