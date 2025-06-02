using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.ValueObjects
{
    /// <summary>
    /// Represents an emotional state with intensity.
    /// </summary>
    public record Emotion(EmotionType Type, float Intensity)
    {
        public static Emotion Create(EmotionType type, float intensity)
        {
            if (intensity < 0f || intensity > 1f)
                throw new ArgumentOutOfRangeException(nameof(intensity), "Intensity must be in [0,1].");
            return new Emotion(type, intensity);
        }
    }
}
