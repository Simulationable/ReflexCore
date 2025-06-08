using Microsoft.Extensions.DependencyInjection;
using ReflexCore.Application.UseCases;
using ReflexCore.CLI.Commands;
using ReflexCore.CLI.Interfaces;
using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using ReflexCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.CLI.Executor
{
    public class CommandExecutor
    {
        private readonly IServiceProvider _services;

        public CommandExecutor(IServiceProvider services)
        {
            _services = services;
        }

        public void Execute(ICommand command)
        {
            switch (command)
            {
                case EvaluateReflexCommand evalCmd:
                    var useCase = _services.GetRequiredService<EvaluateReflexProfile>();

                    var traits = Trait.Create(
                        empathy: 0.5f,
                        assertiveness: 0.5f,
                        impulsiveness: 0.5f,
                        stability: 0.5f,
                        trust: 0.5f,
                        openness: 0.5f,
                        conscientiousness: 0.5f,
                        agreeableness: 0.5f,
                        riskTolerance: 0.5f
                    );

                    var emotion = Emotion.Create(
                        EmotionType.Fear, 
                        0.7f,   
                        DateTimeOffset.UtcNow
                    );

                    var context = new ReflexContext(
                        evalCmd.Situation,
                        emotion,
                        traits,
                        DateTime.UtcNow
                    );

                    var intent = useCase.Execute(context);
                    Console.WriteLine($"Intent: {intent.Intent}");
                    break;

                default:
                    throw new InvalidOperationException("Unknown command.");
            }
        }
    }
}
