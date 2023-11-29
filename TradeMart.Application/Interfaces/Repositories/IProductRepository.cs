using System.Runtime.InteropServices;
using TradeMart.Application.DTOs;
using TradeMart.Application.Models.Pagination;
using TradeMart.Domian.Entities;

namespace TradeMart.Application.Interfaces.Repositories;
public interface IProductRepository
{
    Task<ProductDTO> GetProductAsync(string id);
    Task<PagedResult<ProductDTO>> GetProductsAsync(ProductParams productParams);
}
