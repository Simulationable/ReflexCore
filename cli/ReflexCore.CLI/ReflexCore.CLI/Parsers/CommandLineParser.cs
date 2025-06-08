using ReflexCore.CLI.Commands;
using ReflexCore.CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.CLI.Parsers
{
    public class CommandLineParser
    {
        public ICommand Parse(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException("Usage: --profile <id> --situation <id>");

            var command = new EvaluateReflexCommand();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--profile" && i + 1 < args.Length)
                    command.ProfileId = args[++i];
                else if (args[i] == "--situation" && i + 1 < args.Length)
                    command.Situation = args[++i];
            }

            return command;
        }
    }
}
