using AbashonWeb.Domain.Entities;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;

namespace AbashonWeb.Infrastructure.Implementation.Repositories
{
    public class ErrorLogRepository : Repository<ErrorLog>, IErrorLogRepository
    {
        public ErrorLogRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
