using AbashonWeb.Domain.Entities;
using AbashonWeb.Infrastructure.EF.Repositories;
using AbashonWeb.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Repositories
{
    public interface IClientRepository : IRepository<Client, ApplicationDbContext>
    {
        Task<Client> GetLatestClients();
    }
}
