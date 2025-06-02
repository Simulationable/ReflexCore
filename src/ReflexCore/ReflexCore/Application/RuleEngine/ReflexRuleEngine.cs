using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.RuleEngine
{
    /// <summary>
    /// Layer 4 & 5: Decide action based on rules.
    /// </summary>
    public class ReflexRuleEngine(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public RuleResult Evaluate(string perception, Emotion emotion, Trait traits)
        {
            ArgumentNullException.ThrowIfNull(perception);
            ArgumentNullException.ThrowIfNull(emotion);
            ArgumentNullException.ThrowIfNull(traits);

            _logger.Information(
                "Evaluating rule for perception: {Perception}, emotion: {EmotionType}, intensity: {Intensity}, empathy: {Empathy}",
                perception,
                emotion.Type,
                emotion.Intensity,
                traits.Empathy
            );

            // Production-safe, testable, ready for extension
            if (string.Equals(perception, "CrisisSituation", StringComparison.OrdinalIgnoreCase)
                && emotion.Intensity > 0.7f
                && traits.Empathy > 0.5f)
            {
                return RuleResult.Create(
                    ReflexAction.Escalate,
                    0.95f,
                    "High intensity crisis with high empathy: escalate."
                );
            }

            if (emotion.Type == EmotionType.Despair)
            {
                return RuleResult.Create(
                    ReflexAction.StayWithUser,
                    0.9f,
                    "Detected despair: stay with user."
                );
            }

            if (string.Equals(perception, "NormalSituation", StringComparison.OrdinalIgnoreCase))
            {
                return RuleResult.Create(
                    ReflexAction.OfferSupport,
                    0.7f,
                    "Normal situation, offering support."
                );
            }

            // Plug-in/extension point here (custom rule, ML, config, etc.)

            _logger.Debug("No strong signal found, defaulting to log only.");
            return RuleResult.Create(
                ReflexAction.LogOnly,
                0.5f,
                "No strong signal: log only."
            );
        }
    }
}
