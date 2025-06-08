using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Commands
{
    public class RecordConsentCommand(Guid profileId, string consentType, DateTimeOffset givenAt, string givenBy)
    {
        public Guid ProfileId { get; } = profileId;
        public string ConsentType { get; } = consentType;
        public DateTimeOffset GivenAt { get; } = givenAt;
        public string GivenBy { get; } = givenBy;
    }
}
