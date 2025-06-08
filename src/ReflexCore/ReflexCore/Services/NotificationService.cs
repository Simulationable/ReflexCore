using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Services
{
    public class NotificationService(ILogger logger)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public void Send(string message)
        {
            _logger.Information("NOTIFY: {Message}", message);
        }
    }

}
