using System.Reflection;
using System.Text.Json;
using TradeMart.Domian.Entities;

namespace TradeMart.Infrastructure.Data;
public class DatabaseSeeder
{
    public static async Task SeedProductDataAsync(AppDbContext context)
    {
        if (!context.Brands.Any())
        {
            var brandsData = File.ReadAllText("../TradeMart.Infrastructure/Data/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
            context.Brands.AddRange(brands);
        }

        if (!context.Categories.Any())
        {
            var categoriesData = File.ReadAllText("../TradeMart.Infrastructure/Data/SeedData/categories.json");
            var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
            context.Categories.AddRange(categories);
        }

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("../TradeMart.Infrastructure/Data/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if (!context.ProductCategories.Any())
        {
            var productCategoriesData = File.ReadAllText("../TradeMart.Infrastructure/Data/SeedData/productCategories.json");
            var productCategories = JsonSerializer.Deserialize<List<ProductCategory>>(productCategoriesData);
            context.ProductCategories.AddRange(productCategories);
        }

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }
}
