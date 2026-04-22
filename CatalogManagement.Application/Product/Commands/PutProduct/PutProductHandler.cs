using CatalogManagement.Domain.Repositories;
using MediatR;

namespace CatalogManagement.Application.Product.Commands.PutProduct
{
    internal class PutProductHandler(IProductRepository<Domain.Entities.Product> productRepository)
        : IRequestHandler<PutProductQuery, bool>
    {
        public async Task<bool> Handle(PutProductQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                return false;
            }

            //update product
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.CreatedAt = request.CreatedAt;
            product.UpdatedAt = DateTime.Now;
            product.Description = request.Description;
            product.SKU = request.SKU;
            product.Name = request.Name;
            product.CategoryId = request.CategoryId;

            return await productRepository.Update(product);
        }
    }
}
