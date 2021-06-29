﻿using AbashonWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.EF.Repositories
{
    public interface IRepository<TEntity, TContext>
         where TEntity : BaseEntity
         where TContext : DbContext
    {
        //void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        //void Remove(int id);
        Task RemoveAsync(int id);
        void Remove(TEntity entityToDelete);        
        void Edit(TEntity entityToUpdate);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
