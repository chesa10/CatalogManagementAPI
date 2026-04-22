using CatalogManagement.Application.Category.Queries.GetAllCategories;
using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Category.Commands.AddCategory
{
    internal class AddCategoryHandler(ICategoryRepo categoryRepository)
        : IRequestHandler<AddCategoryQuery, bool>
    {
        public Task<bool> Handle(AddCategoryQuery request, CancellationToken cancellationToken)
        {
            var cat = new CatalogManagement.Domain.Entities.Category();
            cat.Name = request.Name;
            cat.Description = request.Description;
            cat.ParentCategoryId = request.ParentCategoryId;
            return Task.FromResult(categoryRepository.AddCategory(cat));
        }
    }
}
