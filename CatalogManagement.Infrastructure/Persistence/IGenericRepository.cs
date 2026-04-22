using CatalogManagement.Domain.Entities;
using CatalogManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Persistence
{
    public interface IGenericRepository : IProductRepository<Product>
    {
    }
}
