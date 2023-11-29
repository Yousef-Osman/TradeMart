using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TradeMart.Application.DTOs;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Application.Models.Pagination;
using TradeMart.Domian.Entities;
using TradeMart.Infrastructure.Data;
using TradeMart.Application.Mappers;
using TradeMart.Application.Extensions;

namespace TradeMart.Infrastructure.Repositories;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context): base(context)
    {
        _context = context;
    }

    public async Task<ProductDTO> GetProductAsync(string id)
    {
        return await _context.Products
            .Include(a => a.Brand)
            .Include(a => a.Categories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .Select(a => a.ToProductDto())
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<PagedResult<ProductDTO>> GetProductsAsync(ProductParams productParams)
    {
        var query = _context.Products
            .Sort(productParams.OrderBy)
            .Search(productParams.SearchValue)
            .Filter(productParams.Brands, productParams.CategoryId, productParams.VendorId)
            .Include(a => a.Brand)
            .Include(a => a.Categories)
            .ThenInclude(b => b.Category)
            .AsQueryable()
            .AsNoTracking()
            .Select(a => a.ToProductDto());

        return await PagedResult<ProductDTO>.ToPagedListAsync(query, productParams.PageNumber, productParams.PageSize);
    }
}
