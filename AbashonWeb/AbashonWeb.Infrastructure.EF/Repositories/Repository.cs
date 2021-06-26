using AbashonWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.EF.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
                                                where TEntity : BaseEntity
                                                where TContext : DbContext
    {
        protected TContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(TContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(int id)
        {
            var entityToDelete = _dbSet.Find(id);
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

        public virtual async Task<IList<TEntity>> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            var list = await query.ToListAsync();
            return list;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            var enitity = await _dbSet.FindAsync(id);

            return enitity;
        }
    }
}
