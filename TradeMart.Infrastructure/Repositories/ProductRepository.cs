using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Domian.Entities;
using TradeMart.Infrastructure.Data;

namespace TradeMart.Infrastructure.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context): base(context)
    {
        _context = context;
    }

    public IQueryable<Product> GetProductDataQuery([Optional] string userId)
    {
        return _context.Products
            .Where(a => string.IsNullOrEmpty(userId) ? true : a.VendorId == userId)
            .Include(a => a.Brand)
            .Include(a => a.Categories)
            .ThenInclude(b => b.Category)
            .AsNoTracking();
    }

    public async Task<Product> GetProductAsync(string id)
    {
        return await _context.Products
            .Include(a => a.Brand)
            .Include(a => a.Categories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
