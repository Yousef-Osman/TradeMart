using System.ComponentModel.DataAnnotations;

namespace TradeMart.Domian.Entities;
public class Product: BaseEntity
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, StringLength(400)]
    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    [StringLength(1000)]
    public string ImageUrl { get; set; }

    public string BrandId { get; set; }

    public string VendorId { get; set; }

    public Brand Brand { get; set; }
    public ICollection<ProductCategory> Categories { get; set; }
}
