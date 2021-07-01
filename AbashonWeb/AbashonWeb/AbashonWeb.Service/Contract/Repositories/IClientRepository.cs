using AbashonWeb.Domain.Entities;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetLatestClients();
    }
}
