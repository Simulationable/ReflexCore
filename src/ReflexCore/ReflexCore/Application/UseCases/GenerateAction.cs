using ReflexCore.Domain.ValueObjects;
using ReflexCore.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.UseCases
{
    /// <summary>
    /// Generates and dispatches actions from action intents.
    /// </summary>
    public class GenerateAction(ILogger logger, NotificationService notificationService)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly NotificationService _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));

        public void DispatchActions(IEnumerable<ActionIntent> actions)
        {
            ArgumentNullException.ThrowIfNull(actions);

            foreach (var action in actions)
            {
                // Log action
                _logger.Information("Dispatching action: {Action} - Confidence: {Confidence} - {Explanation}",
                    action.Action, action.Confidence, action.Explanation);

                _notificationService.Send(
                    $"[Action: {action.Action}] (Confidence: {action.Confidence:0.00}) {action.Explanation}"
                );
            }
        }
    }
}
