using ReflexCore.Domain.Entities;
using ReflexCore.Models;
using Serilog;
using System;
using ReflexCore.Interfaces;

namespace ReflexCore.Application.UseCases
{
    /// <summary>
    /// UseCase สำหรับการประเมิน Reflex ของผู้ใช้ จากบริบทสถานการณ์
    /// </summary>
    public class EvaluateReflexProfile(
        IReflexCore reflexCore,
        ILogger logger)
    {
        private readonly IReflexCore _reflexCore = reflexCore ?? throw new ArgumentNullException(nameof(reflexCore));

        public ReflexPacket Execute(ReflexContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            var result = _reflexCore.Process(context);
            return result;
        }
    }
}
