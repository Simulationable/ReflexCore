using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Aggregates
{
    /// <summary>
    /// Aggregate root for all trait modifications and their history.
    /// </summary>
    public class TraitAggregate(string ownerId)
    {
        public List<TraitScore> TraitScores { get; } = new();
        public string OwnerId { get; } = ownerId ?? throw new ArgumentNullException(nameof(ownerId));

        public void AddScore(TraitScore score)
        {
            TraitScores.Add(score ?? throw new ArgumentNullException(nameof(score)));
        }

        public float Current(string traitName)
            => TraitScores.FindLast(s => s.TraitName == traitName)?.Value ?? 0f;
    }
}
