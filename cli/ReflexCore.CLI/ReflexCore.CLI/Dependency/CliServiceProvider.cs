using Microsoft.Extensions.DependencyInjection;
using ReflexCore.Application.Analyzers;
using ReflexCore.Application.Output;
using ReflexCore.Application.RuleEngine;
using ReflexCore.Application.TraitLogic;
using ReflexCore.Application;
using ReflexCore.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflexCore.Application.UseCases;

namespace ReflexCore.CLI.Dependency
{
    public static class CliServiceProvider
    {
        public static IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddSingleton<RuleSetProvider>();
            services.AddSingleton<RuleValidator>();
            services.AddSingleton<RuleResultMapper>();
            services.AddSingleton<NotificationFormatter>();
            services.AddSingleton<PerceptionAnalyzer>();
            services.AddSingleton<EmotionAnalyzer>();
            services.AddSingleton<TraitAdjuster>();
            services.AddSingleton<ReflexRuleEngine>();
            services.AddSingleton<ActionGenerator>();
            services.AddSingleton<IReflexCore, ReflexProcessor>();
            services.AddSingleton<EvaluateReflexProfile>();

            services.AddSingleton<ILogger>(Log.Logger);

            return services.BuildServiceProvider();
        }
    }
}
