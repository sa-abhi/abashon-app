using AbashonWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AbashonWeb.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }
        public DbSet<ErrorLog> Errors { get; set; }
        Task<int> SaveChangesAsync();
    }
}
