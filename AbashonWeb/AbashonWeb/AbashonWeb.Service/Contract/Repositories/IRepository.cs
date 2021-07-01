using AbashonWeb.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity         
    {        
        Task AddAsync(TEntity entity);       
        Task RemoveAsync(int id);
        void Remove(TEntity entityToDelete);        
        void Edit(TEntity entityToUpdate);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
