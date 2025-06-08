using ReflexCore.Domain.ValueObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Output
{
    public class ActionGenerator(ILogger logger, NotificationFormatter notificationFormatter)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly NotificationFormatter _notificationFormatter = notificationFormatter ?? throw new ArgumentNullException(nameof(notificationFormatter));

        public ActionIntent Generate(RuleResult ruleResult)
        {
            ArgumentNullException.ThrowIfNull(ruleResult);
            _logger.Information("Generating action intent: {Action}, Confidence {Confidence}", ruleResult.Action, ruleResult.Confidence);

            // Format explanation or action for notification
            var notification = _notificationFormatter.FormatForDisplay(ruleResult.Explanation);

            // Log formatted notification (optional)
            _logger.Information("Notification: {Notification}", notification);

            // Return intent as usual
            return ActionIntent.Create(ruleResult.Action, ruleResult.Confidence, ruleResult.Explanation);
        }
    }
}
