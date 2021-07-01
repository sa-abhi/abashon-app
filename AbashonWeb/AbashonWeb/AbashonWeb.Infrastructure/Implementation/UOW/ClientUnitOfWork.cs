using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using AbashonWeb.Service.Contract.UnitOfWorks;

namespace AbashonWeb.Infrastructure.Implementation.UOW
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
