using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Specifications
{
    /// <summary>
    /// Checks if a trait value exceeds a threshold.
    /// </summary>
    public static class TraitThresholdSpecification
    {
        public static bool IsAbove(Trait trait, float threshold)
            => trait.ToArray().Any(v => v > threshold);

        public static bool IsBelow(Trait trait, float threshold)
            => trait.ToArray().Any(v => v < threshold);
    }
}
