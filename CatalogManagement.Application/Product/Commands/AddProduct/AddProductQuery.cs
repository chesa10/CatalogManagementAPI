using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Commands.AddProduct
{
    public class AddProductQuery : IRequest<bool>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SKU { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? CategoryId { get; set; }
    }
}
