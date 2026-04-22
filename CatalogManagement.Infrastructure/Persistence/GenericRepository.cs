using CatalogManagement.Domain.Entities;
using CatalogManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Persistence
{
    public class GenericRepository : ProductRepository<Product>, IGenericRepository
    {
        public GenericRepository(CatalogManagementContext context) : base(context)
        {
                
        }
    }
}
