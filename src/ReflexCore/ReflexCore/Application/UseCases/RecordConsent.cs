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
    /// Records consent events for user actions.
    /// </summary>
    public class RecordConsent(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public void Record(ConsentLog log)
        {
            // Persist to DB here if needed
            _logger.Information("Consent event: User={UserId}, Type={Type}, At={At}, Granted={Granted}, Context={Context}",
                log.UserId, log.ConsentType, log.GivenAt, log.IsGranted, log.Context);
        }
    }
}
