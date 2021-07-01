using AbashonWeb.Service.Contract.Repositories;

namespace AbashonWeb.Service.Contract.UnitOfWorks
{
    public interface IClientUnitOfWork : IUnitOfWork
    {
        IClientRepository ClientRepository { get; set; }
    }
}
