using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Domain.Repositories
{
    public interface ICategoryRepository<T, TKey> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(TKey id);
        void Add(T value);
    }
}
