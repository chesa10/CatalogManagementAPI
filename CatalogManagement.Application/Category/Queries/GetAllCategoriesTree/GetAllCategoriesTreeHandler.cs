using CatalogManagement.Application.Category.Queries.GetAllCategories;
using CatalogManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Category.Queries.GetAllCategoriesTree
{
    internal class GetAllCategoriesTreeHandler(ICategoryRepo categoryRepository)
        : IRequestHandler<GetAllCategoriesTreeQuery, Dictionary<int, CatalogManagement.Domain.Entities.Category>>
    {
        public Task<Dictionary<int, CatalogManagement.Domain.Entities.Category>> Handle(GetAllCategoriesTreeQuery request, CancellationToken cancellationToken)
        {
            var products = categoryRepository.GetAllTree();
            return Task.FromResult(products);
        }
    }
}
