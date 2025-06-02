using ReflexCore.Domain.Enums;
using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Analyzers
{
    /// <summary>
    /// Layer 2: Analyze or infer emotion.
    /// </summary>
    public class EmotionAnalyzer(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public Emotion Analyze(Emotion input)
        {
            ArgumentNullException.ThrowIfNull(input);

            // Logging with audit trace
            _logger.Information("Analyzing Emotion: {Type} (Intensity: {Intensity})", input.Type, input.Intensity);

            // Basic normalization
            var clampedIntensity = Math.Clamp(input.Intensity, 0f, 1f);

            // Pattern: escalate if despair or anger is too high
            if ((input.Type == EmotionType.Despair || input.Type == EmotionType.Anger) && clampedIntensity > 0.7f)
            {
                _logger.Warning("High-risk emotion detected: {Type} (Intensity: {Intensity})", input.Type, clampedIntensity);
                // Optionally, trigger alert/notify here (via event, hook, etc.)
            }

            // Transform: flatten low-intensity negative emotions to Neutral
            if (clampedIntensity < 0.2f && (
                input.Type == EmotionType.Sadness ||
                input.Type == EmotionType.Despair ||
                input.Type == EmotionType.Fear ||
                input.Type == EmotionType.Disgust
            ))
            {
                _logger.Information("Low-intensity negative emotion normalized to Neutral.");
                return new Emotion(EmotionType.Neutral, 0f);
            }

            // Plugin point: External/AI override (future)
            // if (_plugin != null) return _plugin.Analyze(input);

            // Return processed emotion
            return new Emotion(input.Type, clampedIntensity);
        }
    }
}
