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
    /// Handles logging and auditing when a trait value is changed.
    /// </summary>
    public class LogTraitChange(ILogger logger)
    {
        private readonly ILogger _logger = logger;

        public void LogChange(TraitChangeLog changeLog)
        {
            // Persist to DB here if needed
            _logger.Information("Trait changed: Profile={ProfileId}, Trait={TraitName}, Old={Old}, New={New}, At={At}, By={By}",
                changeLog.ProfileId, changeLog.TraitName, changeLog.OldValue, changeLog.NewValue, changeLog.ChangedAt, changeLog.ChangedBy);
        }
    }
}
