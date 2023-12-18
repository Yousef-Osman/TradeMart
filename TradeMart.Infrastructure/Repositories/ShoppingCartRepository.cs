using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Domian.RedisEntities;

namespace TradeMart.Infrastructure.Repositories;
public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDatabase _database;

    public ShoppingCartRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public async Task<ShoppingCart> GetAsync(string cartId)
    {
        if (string.IsNullOrEmpty(cartId))
            return null;

        var cartData = await _database.StringGetAsync(cartId);
        var cart = cartData.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(cartData);
        return cart;
    }

    public async Task<ShoppingCart> AddOrUpdateAsync(ShoppingCart cart)
    {
        var changed = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

        return !changed ? null : await GetAsync(cart.Id);
    }

    public async Task<bool> DeleteAsync(string cartId)
    {
        return await _database.KeyDeleteAsync(cartId);
    }
}
