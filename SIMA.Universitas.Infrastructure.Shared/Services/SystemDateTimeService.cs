using SIMA.Universitas.Application.Interfaces.Shared;
using System;

namespace SIMA.Universitas.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}