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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });

            #region Client
            modelBuilder.Entity<Client>()
                        .Property(p => p.ClientIdentificatinNumber)
                        .IsRequired()
                        .HasMaxLength(15);

            modelBuilder.Entity<Client>()
                        .Property(p => p.ClientFirstName)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Entity<Client>()
                        .Property(p => p.ClientLastName)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Entity<Client>()
                        .Property(p => p.ContactNo)
                        .IsRequired()
                        .HasMaxLength(20);

            modelBuilder.Entity<Client>()
                        .Property(p => p.Email)                      
                        .HasMaxLength(100);

            modelBuilder.Entity<Client>()
                        .Property(p => p.Address)
                        .HasMaxLength(500);
            #endregion Client

            #region ErrorLog
            modelBuilder.Entity<ErrorLog>()
                        .Property(p => p.LineNo)
                        .HasMaxLength(5);           

            modelBuilder.Entity<ErrorLog>()
                        .Property(p => p.Source)
                        .HasMaxLength(500);

            modelBuilder.Entity<ErrorLog>()
                        .Property(p => p.Arguments)
                        .HasMaxLength(500);

            modelBuilder.Entity<ErrorLog>()
                       .Property(p => p.Message)
                       .HasMaxLength(500);

            modelBuilder.Entity<ErrorLog>()
                       .Property(p => p.PreviewMessage)
                       .HasMaxLength(500);

            modelBuilder.Entity<ErrorLog>()
                       .Property(p => p.StackTrace)
                       .HasMaxLength(500);

            modelBuilder.Entity<ErrorLog>()
                       .Ignore(p => p.UpdatedOn)
                       .Ignore(p => p.UpdatedBy);
            #endregion ErrorLog
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

        #region DbSets
        public DbSet<Client> Clients { get; set; }
        public DbSet<ErrorLog> Errors { get; set; }
        #endregion
    }
}
