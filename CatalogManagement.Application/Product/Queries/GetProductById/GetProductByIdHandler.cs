using CatalogManagement.Application.Product.DTOs;
using CatalogManagement.Application.Product.Queries.GetAllProducts;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Queries.GetProductById
{
    internal class GetProductByIdHandler(IProductRepository<Domain.Entities.Product> productRepository)
        : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product != null) {
                return new ProductDTO() 
                {
                    Id = product.Id, 
                    CategoryId = product.CategoryId,
                    Description = product.Description,  
                    Name = product.Name,
                    CreatedAt = product.CreatedAt,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    SKU = product.SKU,
                    UpdatedAt = product.UpdatedAt
                };
            }

            return new ProductDTO();
        }
    }
}
