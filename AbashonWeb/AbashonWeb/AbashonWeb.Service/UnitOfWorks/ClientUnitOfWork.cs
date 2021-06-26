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
    public class ClientUnitOfWork : UnitOfWork, IClientUnitOfWork
    {
        public IClientRepository ClientRepository { get; set; }

        public ClientUnitOfWork(ApplicationDbContext context,
            IClientRepository clientRepository)
            : base(context)
        {
            ClientRepository = clientRepository;
        }
    }
}
