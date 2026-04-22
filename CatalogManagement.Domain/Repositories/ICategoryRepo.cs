using CatalogManagement.Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Domain.Repositories
{
    public interface ICategoryRepo
    {
        void CategorySeed();
        IEnumerable<Category> GetAll();
        Dictionary<int, Category> GetAllTree();
        bool AddCategory(Category category);
    }
}
