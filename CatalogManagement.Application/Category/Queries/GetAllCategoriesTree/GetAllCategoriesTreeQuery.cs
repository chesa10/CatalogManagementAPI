using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogManagement.Domain.Entities;

namespace CatalogManagement.Application.Category.Queries.GetAllCategoriesTree
{
    public class GetAllCategoriesTreeQuery : IRequest<Dictionary<int, CatalogManagement.Domain.Entities.Category>>
    {
    }
}
