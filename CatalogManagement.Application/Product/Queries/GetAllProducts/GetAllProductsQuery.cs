using CatalogManagement.Domain.Utilities;
using MediatR;
using CatalogManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PaginationParams, IRequest<ProductSearchEngine<Domain.Entities.Product>>
    {
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
