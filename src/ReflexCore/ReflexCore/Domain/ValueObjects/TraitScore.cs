using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.ValueObjects
{
    /// <summary>
    /// TraitScore captures the quantitative evaluation of a trait with historical context.
    /// Immutable.
    /// </summary>
    public record TraitScore(
        string TraitName,
        float Value, // 0-1
        DateTimeOffset Timestamp,
        float? PreviousValue = null,
        IReadOnlyList<float>? History = null
    )
    {
        public static TraitScore Create(string traitName, float value, DateTimeOffset? timestamp = null, float? previous = null, IEnumerable<float>? history = null)
        {
            if (string.IsNullOrWhiteSpace(traitName)) throw new ArgumentException(nameof(traitName));
            if (value < 0f || value > 1f) throw new ArgumentOutOfRangeException(nameof(value));
            return new TraitScore(
                traitName.Trim(), value, timestamp ?? DateTimeOffset.UtcNow,
                previous, history?.ToList() ?? new List<float>());
        }

        public TraitScore AddToHistory(float newValue)
            => this with { History = History?.Append(newValue).ToList() ?? new List<float> { newValue } };

        public float Delta() => PreviousValue.HasValue ? Value - PreviousValue.Value : 0f;

        public override string ToString()
            => $"{TraitName}: {Value:0.00} (Δ {Delta():+#.##;-#.##;+0})";
    }
}
