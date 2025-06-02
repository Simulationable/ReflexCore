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
    }
}
