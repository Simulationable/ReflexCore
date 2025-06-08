using ReflexCore.Domain.Entities;
using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.RuleEngine
{
    /// <summary>
    /// Validates if a rule should trigger for current context.
    /// </summary>
    public class RuleValidator
    {
        public bool IsValid(IRule rule, string perception, Emotion emotion, Trait traits)
        {
            var result = rule.Evaluate(perception, emotion, traits);
            return result.Confidence > 0.5f;
        }
    }
}
