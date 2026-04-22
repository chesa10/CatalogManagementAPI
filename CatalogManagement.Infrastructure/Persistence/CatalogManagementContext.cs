using CatalogManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Persistence
{
    public class CatalogManagementContext : DbContext
    {
        public CatalogManagementContext(DbContextOptions<CatalogManagementContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
    }
}
