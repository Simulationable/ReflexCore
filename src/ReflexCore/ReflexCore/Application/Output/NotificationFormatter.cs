using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.Output
{
    /// <summary>
    /// Formats notifications for display, voice, or external API.
    /// </summary>
    public class NotificationFormatter
    {
        public string FormatForDisplay(string notification)
        {
            return $"[ReflexCore] {notification}";
        }

        public string FormatBatch(IEnumerable<string> notifications)
        {
            return string.Join("\n", notifications.Select(FormatForDisplay));
        }
    }
}
