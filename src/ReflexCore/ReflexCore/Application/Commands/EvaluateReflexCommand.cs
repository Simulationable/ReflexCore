using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Commands
{
    public class EvaluateReflexCommand(Guid profileId, string situation)
    {
        public Guid ProfileId { get; } = profileId;
        public string Situation { get; } = situation;
    }
}
