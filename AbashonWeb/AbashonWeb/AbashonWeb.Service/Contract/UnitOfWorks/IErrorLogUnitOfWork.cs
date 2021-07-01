using AbashonWeb.Service.Contract.Repositories;

namespace AbashonWeb.Service.Contract.UnitOfWorks
{
    public interface IErrorLogUnitOfWork : IUnitOfWork
    {
        IErrorLogRepository ErrorLogRepository { get; set; }
    }
}
