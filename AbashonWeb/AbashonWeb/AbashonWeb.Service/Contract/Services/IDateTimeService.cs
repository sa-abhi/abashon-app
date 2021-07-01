using System;

namespace AbashonWeb.Service.Contract.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
