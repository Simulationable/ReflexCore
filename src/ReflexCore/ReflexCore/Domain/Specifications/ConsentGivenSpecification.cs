using ReflexCore.Domain.Entities;
using ReflexCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Specifications
{
    /// <summary>
    /// Checks if consent has been granted for a type.
    /// </summary>
    public static class ConsentGivenSpecification
    {
        public static bool IsGranted(IEnumerable<ConsentLog> consents, ConsentType type)
            => consents.Any(c => c.ConsentType == type && c.IsGranted);
    }
}
