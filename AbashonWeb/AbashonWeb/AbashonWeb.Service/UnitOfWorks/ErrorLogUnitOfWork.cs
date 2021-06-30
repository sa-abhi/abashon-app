using AbashonWeb.Infrastructure.EF.UnitOfWorks;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using AbashonWeb.Service.Contract.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.UnitOfWorks
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
