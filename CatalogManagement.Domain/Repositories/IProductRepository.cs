using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Domain.Repositories
{
    public interface IProductRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<bool> AddAsync(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task SaveAsync();
    }
}
