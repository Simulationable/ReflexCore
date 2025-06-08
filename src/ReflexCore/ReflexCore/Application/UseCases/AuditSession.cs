using ReflexCore.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexCore.Application.UseCases
{
    /// <summary>
    /// Handles session-level audit logging.
    /// </summary>
    public class AuditSession(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public void Audit(AuditEvent e)
        {
            // Persist to DB here if needed
            _logger.Information("Audit event: User={UserId}, Type={EventType}, Desc={Desc}, At={At}",
                e.UserId, e.EventType, e.Description, e.OccurredAt);
        }
    }
}
