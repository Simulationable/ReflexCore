using ReflexCore.Domain.Entities;
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
    /// Aggregates/multimaps rule results into one actionable RuleResult.
    /// </summary>
    public class RuleResultMapper
    {
        public RuleResult Map(IEnumerable<RuleResult> ruleResults)
        {
            // Priority: Escalate > AlertModerator > OfferSupport > Greet > LogOnly
            var ordered = ruleResults.OrderByDescending(r => r.Confidence).ToList();

            if (ordered.Any(r => r.Action == ReflexAction.Escalate))
                return ordered.First(r => r.Action == ReflexAction.Escalate);

            if (ordered.Any(r => r.Action == ReflexAction.AlertModerator))
                return ordered.First(r => r.Action == ReflexAction.AlertModerator);

            if (ordered.Any(r => r.Action == ReflexAction.OfferSupport))
                return ordered.First(r => r.Action == ReflexAction.OfferSupport);

            if (ordered.Any(r => r.Action == ReflexAction.Greet))
                return ordered.First(r => r.Action == ReflexAction.Greet);

            return ordered.FirstOrDefault() ?? RuleResult.Create(ReflexAction.LogOnly, 0.5f, "No significant rule matched.");
        }
    }
}
