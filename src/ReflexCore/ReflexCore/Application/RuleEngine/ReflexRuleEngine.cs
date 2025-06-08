using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.RuleEngine
{
    /// <summary>
    /// Layer 4 & 5: Decide action based on rules.
    /// </summary>
    public class ReflexRuleEngine(
        ILogger logger,
        RuleSetProvider ruleSetProvider,
        RuleValidator ruleValidator,
        RuleResultMapper ruleResultMapper)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly RuleSetProvider _ruleSetProvider = ruleSetProvider ?? throw new ArgumentNullException(nameof(ruleSetProvider));
        private readonly RuleValidator _ruleValidator = ruleValidator ?? throw new ArgumentNullException(nameof(ruleValidator));
        private readonly RuleResultMapper _ruleResultMapper = ruleResultMapper ?? throw new ArgumentNullException(nameof(ruleResultMapper));

        public RuleResult Evaluate(string perception, Emotion emotion, Trait traits)
        {
            ArgumentNullException.ThrowIfNull(perception);
            ArgumentNullException.ThrowIfNull(emotion);
            ArgumentNullException.ThrowIfNull(traits);

            _logger.Information(
                "Evaluating rule for perception: {Perception}, emotion: {EmotionType}, intensity: {Intensity}, empathy: {Empathy}",
                perception,
                emotion.Type,
                emotion.Intensity,
                traits.Empathy
            );

            var rules = _ruleSetProvider.GetRules(perception);
            var results = new List<RuleResult>();
            foreach (var rule in rules)
            {
                var result = rule.Evaluate(perception, emotion, traits);
                if (_ruleValidator.IsValid(rule, perception, emotion, traits))  
                    results.Add(result);
            }

            var mapped = _ruleResultMapper.Map(results);

            var rawResults = rules.Select(rule => rule.Evaluate(perception, emotion, traits)).ToList();

            var mappedResult = _ruleResultMapper.Map(rawResults);

            _logger.Information(
                "Rule evaluation complete. Action: {Action}, Confidence: {Confidence}, Explanation: {Explanation}",
                mappedResult.Action, mappedResult.Confidence, mappedResult.Explanation);

            return mappedResult;
        }

        public List<RuleResult> EvaluateAll(IEnumerable<(string perception, Emotion emotion, Trait traits)> batch)
        {
            var results = new List<RuleResult>();
            foreach (var item in batch)
            {
                try
                {
                    results.Add(Evaluate(item.perception, item.emotion, item.traits));
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Rule evaluation failed for perception: {Perception}", item.perception);
                }
            }
            return results;
        }
    }
}
