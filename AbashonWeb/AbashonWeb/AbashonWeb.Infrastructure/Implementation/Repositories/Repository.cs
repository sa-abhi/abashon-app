using AbashonWeb.Domain;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract;
using AbashonWeb.Service.Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.Implementation.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
                                                
    {
        protected readonly ApplicationDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }       

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        
        public virtual async Task RemoveAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            Remove(entityToDelete);                      
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            
            _dbSet.Remove(entityToDelete);                   
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;                    
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {            
            IQueryable<TEntity> query = _dbSet;
            var list = await query.ToListAsync();
            return list;                    
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var enitity = await _dbSet.FindAsync(id);
            return enitity; 
        }
    }
}
