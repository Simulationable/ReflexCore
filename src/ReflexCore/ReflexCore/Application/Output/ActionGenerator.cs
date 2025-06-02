using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Output
{
    /// <summary>
    /// Layer 6: Generate action intent for output.
    /// </summary>
    public class ActionGenerator(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public ActionIntent Generate(RuleResult ruleResult)
        {
            ArgumentNullException.ThrowIfNull(ruleResult);
            _logger.Information("Generating action intent: {Action}, Confidence {Confidence}", ruleResult.Action, ruleResult.Confidence);
            return new ActionIntent(ruleResult.Action, ruleResult.Confidence, ruleResult.Explanation);
        }
    }
}
