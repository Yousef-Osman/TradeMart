using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMart.Domian.RedisEntities;
public class ShoppingCart
{
    public ShoppingCart()
    {
        Id = Guid.NewGuid().ToString();
    }

    public ShoppingCart(string id)
    {
        Id = id;
    }

    [StringLength(50)]
    public string Id { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}
