using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.TraitLogic
{
    /// <summary>
    /// Layer 3: Adjust traits based on experience or input.
    /// </summary>
    public class TraitAdjuster(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public Trait Adjust(Trait trait, string perception, Emotion emotion)
        {
            ArgumentNullException.ThrowIfNull(trait);
            ArgumentNullException.ThrowIfNull(perception);
            ArgumentNullException.ThrowIfNull(emotion);

            _logger.Information(
                "Adjusting traits for perception: {Perception}, emotion: {EmotionType}, intensity: {Intensity}, before traits: {Trait}",
                perception, emotion.Type, emotion.Intensity, trait
            );

            // Clone values for mutation (immutable pattern)
            float empathy = trait.Empathy;
            float impulsiveness = trait.Impulsiveness;
            float stability = trait.Stability;
            float riskTolerance = trait.RiskTolerance;

            // Crisis: Up empathy, reduce impulsiveness, up stability (stay calm)
            if (string.Equals(perception, "CrisisSituation", StringComparison.OrdinalIgnoreCase))
            {
                empathy = Math.Min(1.0f, empathy + 0.05f);
                impulsiveness = Math.Max(0.0f, impulsiveness - 0.03f);
                stability = Math.Min(1.0f, stability + 0.02f);

                _logger.Debug("Crisis detected: empathy {Empathy}, impulsiveness {Imp}, stability {Stab}", empathy, impulsiveness, stability);
            }

            // Despair: Boost empathy more if intense, lower risk (be conservative)
            if (emotion.Type == EmotionType.Despair && emotion.Intensity > 0.7f)
            {
                empathy = Math.Min(1.0f, empathy + 0.08f);
                riskTolerance = Math.Max(0.0f, riskTolerance - 0.05f);
                _logger.Debug("Despair detected: empathy {Empathy}, riskTolerance {Risk}", empathy, riskTolerance);
            }

            // Anger: Lower empathy, up impulsiveness
            if (emotion.Type == EmotionType.Anger && emotion.Intensity > 0.5f)
            {
                empathy = Math.Max(0.0f, empathy - 0.04f);
                impulsiveness = Math.Min(1.0f, impulsiveness + 0.06f);
                _logger.Debug("Anger detected: empathy {Empathy}, impulsiveness {Imp}", empathy, impulsiveness);
            }

            // Joy: Up stability, up empathy (positive feedback)
            if (emotion.Type == EmotionType.Joy && emotion.Intensity > 0.4f)
            {
                stability = Math.Min(1.0f, stability + 0.03f);
                empathy = Math.Min(1.0f, empathy + 0.02f);
                _logger.Debug("Joy detected: stability {Stab}, empathy {Empathy}", stability, empathy);
            }

            // Fear: Lower stability, up risk (may trigger avoidance)
            if (emotion.Type == EmotionType.Fear && emotion.Intensity > 0.5f)
            {
                stability = Math.Max(0.0f, stability - 0.04f);
                riskTolerance = Math.Min(1.0f, riskTolerance + 0.04f);
                _logger.Debug("Fear detected: stability {Stab}, riskTolerance {Risk}", stability, riskTolerance);
            }

            // Audit trait diffs
            if (Math.Abs(trait.Empathy - empathy) > 0.001f
                || Math.Abs(trait.Impulsiveness - impulsiveness) > 0.001f
                || Math.Abs(trait.Stability - stability) > 0.001f
                || Math.Abs(trait.RiskTolerance - riskTolerance) > 0.001f)
            {
                _logger.Information(
                    "Traits adjusted: Empathy {OldE}->{NewE}, Impulsiveness {OldI}->{NewI}, Stability {OldS}->{NewS}, RiskTolerance {OldR}->{NewR}",
                    trait.Empathy, empathy,
                    trait.Impulsiveness, impulsiveness,
                    trait.Stability, stability,
                    trait.RiskTolerance, riskTolerance
                );
            }

            // Return new immutable Trait (others field kept as is)
            return trait with
            {
                Empathy = empathy,
                Impulsiveness = impulsiveness,
                Stability = stability,
                RiskTolerance = riskTolerance
            };
        }

    }
}
