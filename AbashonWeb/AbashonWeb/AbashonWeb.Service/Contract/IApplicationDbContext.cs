using AbashonWeb.Domain;
using AbashonWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract
{
    public interface IApplicationDbContext
    {        
        DbSet<Client> Clients { get; set; }
        public DbSet<ErrorLog> Errors { get; set; }

        Task<int> SaveChangesAsync();
    }
}
