using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddMediatR(m => m.RegisterServicesFromAssemblies(appAssembly));
            services.AddValidatorsFromAssembly(appAssembly)
                    .AddFluentValidationAutoValidation();
        }
    }
}
