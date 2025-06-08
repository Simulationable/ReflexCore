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
    /// Layer 2: Analyze or infer emotion, raise alert for high-risk, allow plugin, fully production.
    /// </summary>
    public class EmotionAnalyzer(ILogger logger, IEmotionAlertHandler? alertHandler = null, IEmotionAnalyzerPlugin? plugin = null)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IEmotionAlertHandler? _alertHandler = alertHandler;
        private readonly IEmotionAnalyzerPlugin? _plugin = plugin;

        /// <summary>
        /// Analyze emotion, normalize, trigger alert and plugin if needed.
        /// </summary>
        public Emotion Analyze(Emotion input)
        {
            ArgumentNullException.ThrowIfNull(input);

            _logger.Information("Analyzing Emotion: {Type} (Intensity: {Intensity})", input.Type, input.Intensity);

            var clampedIntensity = Math.Clamp(input.Intensity, 0f, 1f);

            // High-risk: Escalate
            if ((input.Type == EmotionType.Despair || input.Type == EmotionType.Anger) && clampedIntensity > 0.7f)
            {
                _logger.Warning("High-risk emotion detected: {Type} (Intensity: {Intensity})", input.Type, clampedIntensity);
                _alertHandler?.OnHighRiskEmotion(input.Type, clampedIntensity);
            }

            // Normalize low negative to Neutral
            if (clampedIntensity < 0.2f && (
                input.Type == EmotionType.Sadness ||
                input.Type == EmotionType.Despair ||
                input.Type == EmotionType.Fear ||
                input.Type == EmotionType.Disgust
            ))
            {
                _logger.Information("Low-intensity negative emotion normalized to Neutral.");
                var neutral = Emotion.Create(EmotionType.Neutral, 0f);
                _plugin?.OnEmotionNormalized(input, neutral);
                return neutral;
            }

            // Plugin override (if result != null, plugin is in control)
            if (_plugin != null)
            {
                var pluginResult = _plugin.Analyze(input);
                if (pluginResult != null)
                {
                    _logger.Information("Emotion analysis overridden by plugin.");
                    return pluginResult;
                }
            }

            var result = Emotion.Create(input.Type, clampedIntensity);
            _plugin?.OnEmotionAnalyzed(input, result);
            return result;
        }
    }

    // Production-grade alert/event interface
    public interface IEmotionAlertHandler
    {
        void OnHighRiskEmotion(EmotionType type, float intensity);
    }

    // Plugin interface (optional, can do ML/AI extension)
    public interface IEmotionAnalyzerPlugin
    {
        Emotion? Analyze(Emotion input);
        void OnEmotionAnalyzed(Emotion input, Emotion output);
        void OnEmotionNormalized(Emotion input, Emotion output);
    }
}
