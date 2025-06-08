using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Entities
{
    /// <summary>
    /// Represents a consent event for data collection or processing.
    /// </summary>
    public class ConsentLog(Guid consentId, string userId, ConsentType consentType, DateTimeOffset givenAt, bool isGranted, string? context = null)
    {
        public Guid ConsentId { get; } = consentId;
        public string UserId { get; } = userId;
        public ConsentType ConsentType { get; } = consentType;
        public DateTimeOffset GivenAt { get; } = givenAt;
        public bool IsGranted { get; } = isGranted;
        public string? Context { get; } = context;
    }
}
