using TradeMart.Domian.Entities;

namespace TradeMart.Application.Extensions;
public static class ProductExtensions
{
    public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
    {
        query = orderBy switch
        {
            "name" => query.OrderBy(a => a.Name),
            "name_desc" => query.OrderByDescending(a => a.Name),
            "price" => query.OrderBy(a => a.Price),
            "price_desc" => query.OrderByDescending(a => a.Price),
            _ => query.OrderByDescending(a => a.LastModified)
        };

        return query;
    }

    public static IQueryable<Product> Search(this IQueryable<Product> query, string searchValue)
    {
        if (string.IsNullOrWhiteSpace(searchValue))
            return query;

        searchValue = searchValue.ToLower().Trim();

        return query.Where(a => a.Name.ToLower().Contains(searchValue));
    }

    public static IQueryable<Product> Filter(this IQueryable<Product> query, List<string> brands, string categoryId)
    {
        if (brands != null && brands.Count > 0)
            query = query.Where(a => brands.Contains(a.Brand.Id));

        if (!string.IsNullOrWhiteSpace(categoryId))
            query = query.Where(a => a.Id == a.Categories.Where(b=>b.CategoryId == categoryId).Select(b=>b.ProductId).FirstOrDefault());

        return query;
    }
}
