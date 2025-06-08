using ReflexCore.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Analyzers
{
    /// <summary>
    /// Layer 1: Perception/Situation analysis.
    /// </summary>
    public class PerceptionAnalyzer(ILogger logger)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public string Analyze(ReflexContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (string.IsNullOrWhiteSpace(context.SituationId))
            {
                _logger.Warning("SituationId is null or empty; returning 'Unknown'.");
                return "Unknown";
            }

            _logger.Information("Analyzing perception for situation: {SituationId}", context.SituationId);

            var situation = context.SituationId.Trim();

            if (situation.Contains("crisis", StringComparison.OrdinalIgnoreCase))
                return "CrisisSituation";
            if (situation.Contains("normal", StringComparison.OrdinalIgnoreCase))
                return "NormalSituation";

            // TODO: Extend with ML or plugin detection here

            return "Unknown";
        }
    }
}
