using ReflexCore.CLI.Dependency;
using ReflexCore.CLI.Executor;
using ReflexCore.CLI.Parsers;
using System;

namespace ReflexCore.CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = CliServiceProvider.Build();
            var parser = new CommandLineParser();
            var command = parser.Parse(args);
            var executor = new CommandExecutor(serviceProvider);
            executor.Execute(command);
        }
    }
}
