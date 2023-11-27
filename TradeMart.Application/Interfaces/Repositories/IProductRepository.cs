using System.Runtime.InteropServices;
using TradeMart.Domian.Entities;

namespace TradeMart.Application.Interfaces.Repositories;
public interface IProductRepository
{
    Task<Product> GetProductAsync(string id);
    IQueryable<Product> GetProductDataQuery([Optional] string userId);
}
