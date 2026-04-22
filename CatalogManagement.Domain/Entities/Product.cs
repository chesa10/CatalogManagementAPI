using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Domain.Entities
{
    public class Product : IComparable<Product>
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }
    }
}
