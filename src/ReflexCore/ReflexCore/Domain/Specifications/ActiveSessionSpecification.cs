using ReflexCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Domain.Specifications
{
    /// <summary>
    /// Checks if a session is still active.
    /// </summary>
    public static class ActiveSessionSpecification
    {
        public static bool IsActive(ReflexSession session)
            => session.IsActive;
    }
}
