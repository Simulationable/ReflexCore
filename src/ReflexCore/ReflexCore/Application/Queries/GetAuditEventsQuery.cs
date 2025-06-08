using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Queries
{
    public class GetAuditEventsQuery(Guid profileId)
    {
        public Guid ProfileId { get; } = profileId;
    }
}
