using CatalogManagement.Application.Product.DTOs;
using CatalogManagement.Application.Product.Queries.GetProductById;
using CatalogManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Product.Commands.DeleteProductById
{
    internal class DeleteProductByIdHandler(IProductRepository<Domain.Entities.Product> productRepository)
        : IRequestHandler<DeleteProductByIdQuery, bool>
    {
        public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                return false;
            }

            return await productRepository.Delete(product);
        }
    }
}
