using ReflexCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Interfaces
{
    public interface IReflexCore
    {
        ReflexPacket Process(ReflexContext context);
    }
}
