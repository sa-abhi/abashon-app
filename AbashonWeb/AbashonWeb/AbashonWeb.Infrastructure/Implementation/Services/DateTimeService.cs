using AbashonWeb.Service.Contract.Services;
using System;

namespace AbashonWeb.Infrastructure.Implementation.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}