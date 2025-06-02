using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents a cognitive profile for an agent/user.
    /// </summary>
    public class ReflexProfile(string id, Trait traits)
    {
        public string Id { get; set; } = id ?? throw new ArgumentNullException(nameof(id));
        public Trait Traits { get; set; } = traits ?? throw new ArgumentNullException(nameof(traits));
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
