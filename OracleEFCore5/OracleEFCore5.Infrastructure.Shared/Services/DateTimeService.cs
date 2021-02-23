using OracleEFCore5.Application.Interfaces;
using System;

namespace OracleEFCore5.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
