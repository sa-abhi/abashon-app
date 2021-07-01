using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task Complete();
    }
}
