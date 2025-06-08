using ReflexCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Aggregates
{
    /// <summary>
    /// Aggregate root for UserProfile and its linked reflex profiles.
    /// </summary>
    public class UserProfileAggregate(UserProfile user)
    {
        public UserProfile User { get; } = user ?? throw new ArgumentNullException(nameof(user));
        public List<ReflexProfile> ReflexProfiles { get; } = new();

        public void AddProfile(ReflexProfile profile)
        {
            ReflexProfiles.Add(profile ?? throw new ArgumentNullException(nameof(profile)));
            User.AddReflexProfile(profile.ProfileId);
        }
    }
}
