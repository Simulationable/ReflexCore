using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.RuleEngine
{
    /// <summary>
    /// Provides all rules relevant for a given situation/context.
    /// </summary>
    public class RuleSetProvider
    {
        public IEnumerable<IRule> GetRules(string perception)
        {
            // Production: load rule config, filter plugin, db, etc.
            if (perception.Equals("CrisisSituation", StringComparison.OrdinalIgnoreCase))
                return new List<IRule> { new HighRiskRule(), new EmergencyOverrideRule() };
            return new List<IRule> { new NormalRule() };
        }
    }

    public class HighRiskRule : IRule
    {
        public string Name => "HighRisk";

        public RuleResult Evaluate(string perception, Emotion emotion, Trait traits)
        {
            if (traits.RiskTolerance > 0.7f)
            {
                return RuleResult.Create(
                    ReflexAction.Escalate,
                    0.95f,
                    "High risk detected: Escalate action required."
                );
            }
            return RuleResult.Create(
                ReflexAction.LogOnly,
                0.5f,
                "Risk below threshold."
            );
        }
    }

    public class EmergencyOverrideRule : IRule
    {
        public string Name => "EmergencyOverride";

        public RuleResult Evaluate(string perception, Emotion emotion, Trait traits)
        {
            if (traits.Stability < 0.2f)
            {
                return RuleResult.Create(
                    ReflexAction.Escalate,
                    0.98f,
                    "Stability critically low: Emergency override."
                );
            }
            return RuleResult.Create(
                ReflexAction.LogOnly,
                0.5f,
                "Stability sufficient."
            );
        }
    }

    public class NormalRule : IRule
    {
        public string Name => "Normal";

        public RuleResult Evaluate(string perception, Emotion emotion, Trait traits)
        {
            return RuleResult.Create(
                ReflexAction.OfferSupport,
                0.7f,
                "Default normal rule applied."
            );
        }
    }
}
