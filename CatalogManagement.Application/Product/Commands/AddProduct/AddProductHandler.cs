using CatalogManagement.Application.Product.Commands.DeleteProductById;
using CatalogManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Commands.AddProduct
{
    public class AddProductHandler(IProductRepository<Domain.Entities.Product> productRepository)
        : IRequestHandler<AddProductQuery, bool>
    {
        public async Task<bool> Handle(AddProductQuery request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product();

            //Add product
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            product.Description = request.Description;
            product.SKU = request.SKU;
            product.Name = request.Name;
            product.CategoryId = request.CategoryId;

            return await productRepository.AddAsync(product);
        }
    }
}
