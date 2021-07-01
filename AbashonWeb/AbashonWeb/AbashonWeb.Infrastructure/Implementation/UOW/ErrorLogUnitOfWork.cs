using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using AbashonWeb.Service.Contract.UnitOfWorks;

namespace AbashonWeb.Infrastructure.Implementation.UOW
{
    public class ErrorLogUnitOfWork : UnitOfWork, IErrorLogUnitOfWork
    {
        public IErrorLogRepository ErrorLogRepository { get; set; }

        public ErrorLogUnitOfWork(ApplicationDbContext context,
            IErrorLogRepository errorLogRepository)
            : base(context)
        {
            ErrorLogRepository = errorLogRepository;
        }
        
    }
}
