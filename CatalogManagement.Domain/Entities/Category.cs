using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Children = new List<Category>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Category> Children { get; set; } = new List<Category>();
    }
}
