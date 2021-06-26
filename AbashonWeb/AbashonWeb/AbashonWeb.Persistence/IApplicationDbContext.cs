using AbashonWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AbashonWeb.Persistence
{
    public interface IApplicationDbContext
    {
        //DbSet<Category> Categories { get; set; }
        //DbSet<Customer> Customers { get; set; }
        DbSet<Client> Clients { get; set; }
        //DbSet<Order> Orders { get; set; }
        //DbSet<Product> Products { get; set; }
        //DbSet<Supplier> Suppliers { get; set; }

        Task<int> SaveChangesAsync();
    }
}
