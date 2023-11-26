namespace TradeMart.Domian.Entities;
internal class ProductCategory
{
    public string ProductId { get; set; }
    public string CategoryId { get; set; }
    public Product Product { get; set; }
    public Category Category { get; set; }
}
