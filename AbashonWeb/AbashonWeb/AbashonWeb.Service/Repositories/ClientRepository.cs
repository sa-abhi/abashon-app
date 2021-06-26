using AbashonWeb.Domain.Entities;
using AbashonWeb.Infrastructure.EF.Repositories;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Repositories
{
    public class ClientRepository : Repository<Client, ApplicationDbContext>, IClientRepository
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
