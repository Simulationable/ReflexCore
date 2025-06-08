using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.ValueObjects
{
    /// <summary>
    /// Represents a snapshot of a single core emotion with intensity.
    /// Immutable.
    /// </summary>
    public record Emotion(
        EmotionType Type,
        float Intensity, // 0-1
        DateTimeOffset Timestamp
    )
    {
        public static Emotion Create(EmotionType type, float intensity, DateTimeOffset? timestamp = null)
        {
            if (intensity < 0f || intensity > 1f)
                throw new ArgumentOutOfRangeException(nameof(intensity), "Emotion intensity must be between 0 and 1.");
            return new Emotion(type, intensity, timestamp ?? DateTimeOffset.UtcNow);
        }

        public override string ToString()
            => $"[{Type}]({Intensity:0.00}) @ {Timestamp:u}";
    }
}
