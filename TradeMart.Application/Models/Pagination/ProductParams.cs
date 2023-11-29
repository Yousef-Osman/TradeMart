namespace TradeMart.Application.Models.Pagination;
public class ProductParams : PaginationParams
{
    public string OrderBy { get; set; }
    public string SearchValue { get; set; }
    public string CategoryId { get; set; }
    public List<string> Brands { get; set; }
}
