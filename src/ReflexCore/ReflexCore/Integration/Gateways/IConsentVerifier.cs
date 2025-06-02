using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Integration.Gateways
{
    public interface IConsentVerifier
    {
        bool HasConsent(string userId, string action);
    }
}
