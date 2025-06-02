using ReflexCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Integration.Gateways
{
    public interface IMemoryLogger
    {
        void Log(ReflexContext context, ReflexPacket packet);
    }
}
