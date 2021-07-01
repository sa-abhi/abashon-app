using AbashonWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Services
{
    public interface IClientService
    {
        Task<int> CreateClientAsync(Client client);
        Task<IEnumerable<Client>> GetClientsAsync();
    }
}
