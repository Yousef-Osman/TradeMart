using Microsoft.EntityFrameworkCore;

namespace TradeMart.Application.Models.Pagination;
public class PagedResult<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public List<T> Data { get; set; } = new List<T>();

    public PagedResult(List<T> items, int pageNumber, int pageSize, int itemsCount)
    {
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalCount = itemsCount;
        TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);
        Data.AddRange(items);
    }

    public static async Task<PagedResult<T>> ToPagedListAsync(IQueryable<T> query, int pageNumber, int pageSize)
    {
        var itemsCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<T>(items, pageNumber, pageSize, itemsCount);
    }
}
