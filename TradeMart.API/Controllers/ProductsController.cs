using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Application.Models.Pagination;
using TradeMart.Domian.Entities;


namespace TradeMart.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepo;
    private readonly IGenericRepository<Brand> _brandRepo;
    private readonly IGenericRepository<Category> _categoryRepo;
    private readonly IConfiguration _config;

    public ProductsController(IProductRepository productRepo,
                              IGenericRepository<Brand> brandRepo,
                              IGenericRepository<Category> CategoryRepo,
                              IConfiguration config)
    {
        _productRepo = productRepo;
        _brandRepo = brandRepo;
        _categoryRepo = CategoryRepo;
        _config = config;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
    {
        var pagedResult = await _productRepo.GetProductsAsync(productParams);

        foreach (var product in pagedResult.Data)
        {
            if (product.ImageUrl != null)
                product.ImageUrl = _config["ApiUrl"] + product.ImageUrl;
        }

        return Ok(pagedResult);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await _productRepo.GetProductAsync(id);

        if (product.ImageUrl != null)
            product.ImageUrl = _config["ApiUrl"] + product.ImageUrl;

        return Ok(product);
    }

    [HttpGet("brands/{id}")]
    public async Task<IActionResult> GetBrand(string id)
    {
        var brand = await _brandRepo.GetByIdAsync(id);
        brand.ImageUrl = _config["ApiUrl"] + brand.ImageUrl;
        return Ok(brand);
    }

    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands()
    {
        var data = await _brandRepo.GetDataQuery().Select(a => new {
            a.Id,
            a.Name,
            ImageUrl = _config["ApiUrl"] + a.ImageUrl
        }).ToListAsync();
        return Ok(data);
    }

    [HttpGet("brands/names")]
    public async Task<IActionResult> GetBrandsNames()
    {
        var data = await _brandRepo.GetDataQuery().Select(a=>new {a.Id, a.Name}).ToListAsync();
        return Ok(data);
    }

    [HttpGet("categories/{id}")]
    public async Task<IActionResult> GetCategory(string id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        category.ImageUrl = _config["ApiUrl"] + category.ImageUrl;
        return Ok(category);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        var data = await _categoryRepo.GetDataQuery().Select(a => new { 
            a.Id, 
            a.Name,
            ImageUrl = _config["ApiUrl"] + a.ImageUrl
        }).ToListAsync();
        return Ok(data);
    }

    [HttpGet("categories/Names")]
    public async Task<IActionResult> GetCategoriesNames()
    {
        var data = await _categoryRepo.GetDataQuery().Select(a => new { a.Id, a.Name }).ToListAsync();
        return Ok(data);
    }
}
