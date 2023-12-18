using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Domian.RedisEntities;

namespace TradeMart.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartRepository _cartRepitory;

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
    {
        _cartRepitory = shoppingCartRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCart(string id)
    {
        var cart = await _cartRepitory.GetAsync(id);
        return Ok(cart ?? new ShoppingCart(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateCart(ShoppingCart cart)
    {
        var storedCart = await _cartRepitory.AddOrUpdateAsync(cart);
        return Ok(storedCart);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCart(string id)
    {
        return Ok(await _cartRepitory.DeleteAsync(id));
    }
}
