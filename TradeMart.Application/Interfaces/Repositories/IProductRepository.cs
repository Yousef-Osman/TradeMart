using System.Runtime.InteropServices;
using TradeMart.Application.DTOs;
using TradeMart.Application.Models.Pagination;
using TradeMart.Domian.Entities;

namespace TradeMart.Application.Interfaces.Repositories;
public interface IProductRepository
{
    Task<Product> GetProductAsync(string id);
    IQueryable<Product> GetProductDataQuery([Optional] string userId);
    Task<PagedResult<ProductDTO>> GetProductsAsync(ProductParams productParams);
}
