using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Enums
{
    /// <summary>
    /// Consent event category.
    /// </summary>
    public enum ConsentType
    {
        General,
        DataCollection,
        ThirdParty,
        EmergencyOverride,
        Custom
    }
}
