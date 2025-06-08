using ReflexCore.CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.CLI.Commands
{
    public class EvaluateReflexCommand : ICommand
    {
        public string ProfileId { get; set; } = string.Empty;
        public string Situation { get; set; } = string.Empty;
    }
}
