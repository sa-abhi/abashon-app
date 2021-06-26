using AbashonWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AbashonWeb.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private IConfiguration _configuration;
        public ApplicationDbContext()
        {
           ;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public DbSet<Client> Clients { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder
            //    .UseSqlServer("DataSource=app.db");
            //}

            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("AbashonDbConn"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
