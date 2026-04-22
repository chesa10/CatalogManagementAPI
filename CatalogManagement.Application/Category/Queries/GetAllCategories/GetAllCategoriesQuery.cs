using CatalogManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CatalogManagement.Domain.Entities.Category>>
    {
    }
}
