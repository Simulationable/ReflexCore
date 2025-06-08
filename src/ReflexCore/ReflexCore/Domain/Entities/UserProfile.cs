using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents core user profile information and references to reflex profiles.
    /// </summary>
    public class UserProfile
    {
        public string UserId { get; }
        public string DisplayName { get; }
        public string Email { get; }
        public List<Guid> ReflexProfiles { get; }

        public UserProfile(string userId, string displayName, string email)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException(nameof(userId));
            if (string.IsNullOrWhiteSpace(displayName)) throw new ArgumentException(nameof(displayName));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(nameof(email));
            UserId = userId.Trim();
            DisplayName = displayName.Trim();
            Email = email.Trim().ToLowerInvariant();
            ReflexProfiles = new();
        }

        public void AddReflexProfile(Guid profileId)
        {
            if (!ReflexProfiles.Contains(profileId))
                ReflexProfiles.Add(profileId);
        }
    }
}
