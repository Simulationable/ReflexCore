using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.ValueObjects
{
    /// <summary>
    /// Represents personality traits (core dimensions).
    /// Immutable, use Create() for validated construction.
    /// </summary>
    public record Trait(
        float Empathy,
        float Assertiveness,
        float Impulsiveness,
        float Stability,
        float Trust,
        float Openness,
        float Conscientiousness,
        float Agreeableness,
        float RiskTolerance
    )
    {
        public static Trait Create(
            float empathy,
            float assertiveness,
            float impulsiveness,
            float stability,
            float trust,
            float openness,
            float conscientiousness,
            float agreeableness,
            float riskTolerance
        )
        {
            return new Trait(
                Clamp(empathy),
                Clamp(assertiveness),
                Clamp(impulsiveness),
                Clamp(stability),
                Clamp(trust),
                Clamp(openness),
                Clamp(conscientiousness),
                Clamp(agreeableness),
                Clamp(riskTolerance)
            );
        }

        private static float Clamp(float value)
        {
            if (value < 0f || value > 1f)
                throw new ArgumentOutOfRangeException(nameof(value), "Trait values must be in [0,1].");
            return value;
        }

        /// <summary>
        /// Returns a new Trait with one dimension changed (immutable pattern).
        /// </summary>
        public Trait With(
            float? empathy = null,
            float? assertiveness = null,
            float? impulsiveness = null,
            float? stability = null,
            float? trust = null,
            float? openness = null,
            float? conscientiousness = null,
            float? agreeableness = null,
            float? riskTolerance = null
        ) => Create(
            empathy ?? this.Empathy,
            assertiveness ?? this.Assertiveness,
            impulsiveness ?? this.Impulsiveness,
            stability ?? this.Stability,
            trust ?? this.Trust,
            openness ?? this.Openness,
            conscientiousness ?? this.Conscientiousness,
            agreeableness ?? this.Agreeableness,
            riskTolerance ?? this.RiskTolerance
        );

        /// <summary>
        /// Return all values as a float array (for ML or normalization).
        /// </summary>
        public float[] ToArray() => new[]
        {
            Empathy, Assertiveness, Impulsiveness, Stability,
            Trust, Openness, Conscientiousness, Agreeableness, RiskTolerance
        };

        /// <summary>
        /// Average value of all traits.
        /// </summary>
        public float Average() => ToArray().Length == 0 ? 0f : (float)ToArray().Average();

        /// <summary>
        /// Human-readable string.
        /// </summary>
        public override string ToString()
        {
            return $"Trait[Empathy={Empathy}, Assertiveness={Assertiveness}, Impulsiveness={Impulsiveness}, Stability={Stability}, Trust={Trust}, Openness={Openness}, Conscientiousness={Conscientiousness}, Agreeableness={Agreeableness}, RiskTolerance={RiskTolerance}]";
        }
    }
}
