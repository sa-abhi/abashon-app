using AbashonWeb.Domain.Entities;
using AbashonWeb.Infrastructure.EF.Repositories;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Repositories
{
    public class ErrorLogRepository : Repository<ErrorLog, ApplicationDbContext>, IErrorLogRepository
    {
        public ErrorLogRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
