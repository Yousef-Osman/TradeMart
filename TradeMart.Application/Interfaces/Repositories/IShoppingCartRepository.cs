using TradeMart.Domian.RedisEntities;

namespace TradeMart.Application.Interfaces.Repositories;
public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetAsync(string cartId);
    Task<ShoppingCart> AddOrUpdateAsync(ShoppingCart cart);
    Task<bool> DeleteAsync(string cartId);
}
