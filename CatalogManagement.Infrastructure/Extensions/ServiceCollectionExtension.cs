using CatalogManagement.Domain.Repositories;
using CatalogManagement.Infrastructure.Persistence;
using CatalogManagement.Infrastructure.Repositories;
using CatalogManagement.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configure)
        {
            var connectionString = configure.GetConnectionString("CatalogManagementConnectionString");
            services.AddDbContext<CatalogManagementContext>(options => options.UseSqlServer(connectionString, c => c.MigrationsAssembly("CatalogManagementAPI")));
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped(typeof(IProductRepository<>), typeof(ProductRepository<>));
            services.AddSingleton(typeof(ICategoryRepository<,>), typeof(CategoryRepository<,>));
            services.AddScoped<IProductSeeder, ProductSeeder>();
            services.AddSingleton<ICategoryRepo, CategorySeeder>();
            
        }
    }
}
