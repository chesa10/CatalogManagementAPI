using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.DTOs
{
    public record AllProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Category { get; set; }
    }
}
