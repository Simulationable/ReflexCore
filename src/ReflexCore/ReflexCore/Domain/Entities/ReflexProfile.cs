using ReflexCore.Domain.Events;
using ReflexCore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// ReflexProfile aggregates all traits, emotional history, audit and consent for a user/session.
    /// </summary>
    public class ReflexProfile
    {
        public Guid ProfileId { get; }
        public string UserId { get; }
        public Trait Traits { get; private set; }
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset LastUpdated { get; private set; }
        public List<Emotion> EmotionHistory { get; }
        public Emotion? CurrentEmotion => EmotionHistory.Count > 0 ? EmotionHistory[^1] : null;
        public List<TraitScore> TraitChangeHistory { get; }
        public List<Guid> ActiveSessions { get; }

        public event EventHandler<TraitChangedEvent>? TraitChanged;

        public ReflexProfile(Guid profileId, string userId, Trait traits)
        {
            ProfileId = profileId;
            UserId = userId;
            Traits = traits;
            CreatedAt = DateTimeOffset.UtcNow;
            LastUpdated = CreatedAt;
            EmotionHistory = new();
            TraitChangeHistory = new();
            ActiveSessions = new();
        }

        public void ApplyTraitChange(Trait newTraits)
        {
            var prev = Traits;
            Traits = newTraits;
            LastUpdated = DateTimeOffset.UtcNow;
            TraitChangeHistory.Add(new TraitScore("composite", newTraits.Average(), LastUpdated, prev.Average()));
            TraitChanged?.Invoke(this, new TraitChangedEvent(ProfileId, prev, newTraits, LastUpdated));
        }

        public void AddEmotion(Emotion emotion)
        {
            EmotionHistory.Add(emotion);
            LastUpdated = DateTimeOffset.UtcNow;
        }

        public void StartSession(Guid sessionId)
        {
            if (!ActiveSessions.Contains(sessionId))
                ActiveSessions.Add(sessionId);
        }

        public void EndSession(Guid sessionId)
        {
            ActiveSessions.Remove(sessionId);
        }
    }
}
