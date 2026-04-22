using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogManagement.Infrastructure.Repositories
{
    public class CategoryRepository<T, Tkey> : ICategoryRepository<T, Tkey> where T : class
    {
        private readonly Dictionary<int, Category> _category = new Dictionary<int, Category>();

        private readonly Dictionary<Tkey, T> _storage = new Dictionary<Tkey, T>();
        private readonly Func<T, Tkey> _keySelector;
        public CategoryRepository(Func<T, Tkey> keySelector)
        {
            _keySelector = keySelector;
        }
        public T GetById(Tkey id)
        {
            return _storage.TryGetValue(id, out var entity) ? entity : null;
        }
        public IEnumerable<T> GetAll()
        {
            return _storage.Values.ToList();
        }

        public void Add(T entity)
        {
            Tkey key = _keySelector(entity);
            _storage[key] = entity;
        }
    }
}
