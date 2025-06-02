using ReflexCore.Application.Analyzers;
using ReflexCore.Application.Output;
using ReflexCore.Application.RuleEngine;
using ReflexCore.Application.TraitLogic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application
{
    /// <summary>
    /// Orchestrates all reflex layers (stateless).
    /// </summary>
    public class ReflexProcessor(
        PerceptionAnalyzer perceptionAnalyzer,
        EmotionAnalyzer emotionAnalyzer,
        TraitAdjuster traitAdjuster,
        ReflexRuleEngine ruleEngine,
        ActionGenerator actionGenerator,
        ILogger logger
        ) : Interfaces.IReflexCore
    {
        private readonly PerceptionAnalyzer _perceptionAnalyzer = perceptionAnalyzer;
        private readonly EmotionAnalyzer _emotionAnalyzer = emotionAnalyzer;
        private readonly TraitAdjuster _traitAdjuster = traitAdjuster;
        private readonly ReflexRuleEngine _ruleEngine = ruleEngine;
        private readonly ActionGenerator _actionGenerator = actionGenerator;
        private readonly ILogger _logger = logger;

        public Models.ReflexPacket Process(Models.ReflexContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _logger.Information("Processing reflex packet for situation {SituationId}", context.SituationId);

            var perception = _perceptionAnalyzer.Analyze(context);
            var emotion = _emotionAnalyzer.Analyze(context.Emotion);
            var traits = _traitAdjuster.Adjust(context.Traits, perception, emotion);
            var ruleResult = _ruleEngine.Evaluate(perception, emotion, traits);
            var actionIntent = _actionGenerator.Generate(ruleResult);

            var packet = new Models.ReflexPacket(actionIntent, DateTime.UtcNow);

            _logger.Information("Reflex processing completed. Action: {Action}, Confidence: {Confidence}", actionIntent.Action, actionIntent.Confidence);
            return packet;
        }
    }
}
