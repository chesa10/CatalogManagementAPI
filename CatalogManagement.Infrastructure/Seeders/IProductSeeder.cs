using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Infrastructure.Seeders
{
    public interface IProductSeeder
    {
        Task ProductSeed();
    }
}
