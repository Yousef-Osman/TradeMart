using TradeMart.Application.DTOs;
using TradeMart.Domian.Entities;

namespace TradeMart.Application.Mappers;
public static class ProductMappers
{
    public static ProductDTO ToProductDto(this Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Stock = product.Stock,
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Brand = product.Brand.Name,
            Categories = product.Categories.Select(a=>a.Category.Name).ToList(),
            Created = product.Created,
            LastModified = product.LastModified,
        };
    }

    public static Product ToProduct(this ProductDTO dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Stock = dto.Stock,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price,
        };
    }
}
