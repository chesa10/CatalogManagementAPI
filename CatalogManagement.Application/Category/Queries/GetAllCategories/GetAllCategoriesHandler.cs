using CatalogManagement.Application.Product.Queries.GetAllProducts;
using CatalogManagement.Domain.Repositories;
using CatalogManagement.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler(ICategoryRepo categoryRepository)
        : IRequestHandler<GetAllCategoriesQuery, List<Domain.Entities.Category>>
    {
        public Task<List<Domain.Entities.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var products = categoryRepository.GetAll();
            return Task.FromResult(products.ToList());
        }
    }
}
