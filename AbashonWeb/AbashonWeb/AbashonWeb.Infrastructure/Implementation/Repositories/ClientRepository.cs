using AbashonWeb.Domain.Entities;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.Implementation.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {

        }
        public async Task<Client> GetLatestClients()
        {
            var latestClients = await _dbContext.Clients.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return latestClients;
        }
    }
}
