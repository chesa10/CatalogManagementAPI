using CatalogManagement.Domain.Repositories;
using CatalogManagement.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsHandler(IProductRepository<Domain.Entities.Product> productRepository)
        : IRequestHandler<GetAllProductsQuery, ProductSearchEngine<Domain.Entities.Product>>
    {
        public async Task<ProductSearchEngine<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var propertyFilters = new List<string>() { "Name", "Description" };

            if (request.CategoryId != null && request.CategoryId > 0)
            {
                products = products.Where(p => p.CategoryId == request.CategoryId);
            }

            return await ProductSearchEngine<Domain.Entities.Product>.CreateAsync(products, request.PageNumber, request.PageSize, request.Name);//, propertyFilters, request.Name);
        }
    }
}
