using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMart.Application.DTOs;
public class ProductDTO
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public string Brand { get; set; }
    public List<string> Categories { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
