using System.ComponentModel.DataAnnotations;

namespace TradeMart.Domian.RedisEntities;
public class CartItem
{
    public CartItem()
    {
        Id = Guid.NewGuid().ToString();
        Created = DateTime.Now;
        LastModified = DateTime.Now;
    }

    [StringLength(50)]
    public string Id { get; set; }

    [StringLength(100)]
    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    [StringLength(1000)]
    public string imageUrl { get; set; }

    [StringLength(100)]
    public string Brand { get; set; }

    [StringLength(100)]
    public string Category { get; set; }

    public DateTime Created { get; set; }

    public DateTime? LastModified { get; set; }
}
