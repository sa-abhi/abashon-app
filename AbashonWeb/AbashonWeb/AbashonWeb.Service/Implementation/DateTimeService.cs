using AbashonWeb.Service.Contract;
using System;

namespace AbashonWeb.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}