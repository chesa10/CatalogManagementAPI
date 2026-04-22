using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Seeders
{
    public class CategorySeeder : ICategoryRepo
    {
        CategoryRepository<Category, int> repo = new CategoryRepository<Category, int>(c => c.Id);
        public bool AddCategory(Category category)
        {
            var dictionary = repo.GetAll().ToDictionary(c => c.Id, c => c);
            if (dictionary != null) {
                var c = dictionary.Where(p => p.Value.ParentCategoryId == category.ParentCategoryId || category.ParentCategoryId == null);
                if (c != null && c.Any())
                {
                    var newId = dictionary.OrderByDescending(p => p.Value.Id).Select(p => p.Value.Id).FirstOrDefault();
                    category.Id = newId + 1;
                    repo.Add(category);
                }
                return false;
            }
            return false;
        }

        public void CategorySeed()
        {
            repo.Add(new Domain.Entities.Category() { Id = 1, Name = "Electronic", Description = ""});
            repo.Add(new Domain.Entities.Category() { Id = 2, Name = "Laptops", Description = "", ParentCategoryId = 1 });
            repo.Add(new Domain.Entities.Category() { Id = 3, Name = "Phones", Description = "", ParentCategoryId = 1 });
            repo.Add(new Domain.Entities.Category() { Id = 4, Name = "Books", Description = "" });
            repo.Add(new Domain.Entities.Category() { Id = 5, Name = "Romance", Description = "", ParentCategoryId = 4 });
            repo.Add(new Domain.Entities.Category() { Id = 6, Name = "comedy", Description = "", ParentCategoryId = 4});
            repo.Add(new Domain.Entities.Category() { Id = 7, Name = "Fantasy", Description = "", ParentCategoryId = 4 });
            repo.Add(new Domain.Entities.Category() { Id = 8, Name = "Sci-Fi ", Description = "", ParentCategoryId = 4 });
            repo.Add(new Domain.Entities.Category() { Id = 9, Name = "Furniture", Description = "" });
            repo.Add(new Domain.Entities.Category() { Id = 10, Name = "living", Description = "", ParentCategoryId = 9 });
            repo.Add(new Domain.Entities.Category() { Id = 11, Name = "bedroom", Description = "", ParentCategoryId = 9 });
            repo.Add(new Domain.Entities.Category() { Id = 12, Name = "Antique", Description = "", ParentCategoryId = 9 });
        }

        public IEnumerable<Category> GetAll() 
        {
            return repo.GetAll();
        }

        public Dictionary<int, Category> GetAllTree()
        {
            var dictionary = repo.GetAll().ToDictionary(c => c.Id, c => c);
            Category root = null;
            foreach (var item in repo.GetAll())
            {
                if (item.ParentCategoryId.HasValue)
                {
                    if (dictionary.ContainsKey(item.ParentCategoryId.Value))
                    {
                        dictionary[item.ParentCategoryId.Value].Children.Add(item);
                    }
                }
                else
                {
                    root = item;
                }
            }
            return dictionary;
        }
    }
}
