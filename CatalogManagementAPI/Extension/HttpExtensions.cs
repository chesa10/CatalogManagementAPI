using CatalogManagement.Domain.Utilities;
using CatalogManagementAPI.Helpers;
using System.Text.Json;

namespace CatalogManagementAPI.Extension
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader<T>(this HttpResponse response, ProductSearchEngine<T> data)
        {
            var d = new PaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Append("Pagination", JsonSerializer.Serialize(d, jsonOptions));
            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
            
        }
    }
}
