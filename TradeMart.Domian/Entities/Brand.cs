using System.ComponentModel.DataAnnotations;

namespace TradeMart.Domian.Entities;
internal class Brand: BaseEntity
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [StringLength(400)]
    public string Description { get; set; }

    [StringLength(1000)]
    public string ImageUrl { get; set; }
}
