using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMart.Application.DTOs;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Application.Mappers;
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

    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands()
    {
        return Ok(await _brandRepo.GetAllAsync());
    }

    [HttpGet("brands/{id}")]
    public async Task<IActionResult> GetBrand(string id)
    {
        return Ok(await _brandRepo.GetByIdAsync(id));
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _categoryRepo.GetAllAsync());
    }

    [HttpGet("categories/{id}")]
    public async Task<IActionResult> GetCategory(string id)
    {
        return Ok(await _categoryRepo.GetByIdAsync(id));
    }
}
