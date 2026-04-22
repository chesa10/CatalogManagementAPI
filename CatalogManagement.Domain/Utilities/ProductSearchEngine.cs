using Microsoft.EntityFrameworkCore;

namespace CatalogManagement.Domain.Utilities
{
    public class ProductSearchEngine<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public ProductSearchEngine(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public static async Task<ProductSearchEngine<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, string searchValue)//, string searchValue ,List<string> searchByPropertyList)
        {
            var freshList = await source.ToListAsync();
            freshList = Search(freshList, searchValue, "Name");
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            var count =  freshList.Count();
            var items = freshList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new ProductSearchEngine<T>(items, count, pageNumber, pageSize);
        }
        public static List<T> Search(List<T> list, string search, string propertyName)
        {
            int threshold = 2;

            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(x =>
                {
                    var property = x.GetType().GetProperty(propertyName);
                    var propertyValue = property != null ? property.GetValue(x).ToString().ToLower() : "";
                    return property != null && ((LevenshteinDistance.Calculate(propertyValue, search) <= threshold || propertyValue.Contains(search.ToLower())));
                }).ToList();
            }
            return list;
        }
        
        // to support multiple properties
        public static List<T> Search(List<T> list, string search, List<string> propertyName)
        {
            int threshold = 2;
            if (!string.IsNullOrEmpty(search))
            {
                foreach (var item in propertyName)
                {
                    var newSearch = list.Where(x =>
                    {
                        var property = x.GetType().GetProperty(item);
                        return property != null && (LevenshteinDistance.Calculate(property.GetValue(x).ToString(), search) <= threshold);
                    }).ToList();

                    list.AddRange(newSearch);
                }
            }

            return list.Distinct<T>().ToList();
        }
    }
}
