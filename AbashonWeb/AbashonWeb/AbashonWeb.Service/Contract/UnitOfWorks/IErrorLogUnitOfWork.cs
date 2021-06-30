using AbashonWeb.Infrastructure.EF.UnitOfWorks;
using AbashonWeb.Service.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.UnitOfWorks
{
    public interface IErrorLogUnitOfWork : IUnitOfWork
    {
        IErrorLogRepository ErrorLogRepository { get; set; }
    }
}
