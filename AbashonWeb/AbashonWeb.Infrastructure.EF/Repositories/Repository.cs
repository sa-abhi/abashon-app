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

        //public virtual void Add(TEntity entity)
        //{
        //    _dbSet.Add(entity);
        //}

        public virtual async Task AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //public virtual void Remove(int id)
        //{
        //    var entityToDelete = _dbSet.Find(id);
        //    Remove(entityToDelete);
        //}

        public virtual async Task RemoveAsync(int id)
        {
            try
            {
                var entityToDelete = await _dbSet.FindAsync(id);
                Remove(entityToDelete);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            try
            {
                if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                var list = await query.ToListAsync();
                return list;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var enitity = await _dbSet.FindAsync(id);
                return enitity;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
