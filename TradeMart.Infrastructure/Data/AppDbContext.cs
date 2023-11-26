using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TradeMart.Domian.Entities;

namespace TradeMart.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Product>().HasQueryFilter(a => a.IsDeleted == false);
        builder.Entity<Brand>().HasQueryFilter(a => a.IsDeleted == false);
        builder.Entity<Category>().HasQueryFilter(a => a.IsDeleted == false);
        builder.Entity<ProductCategory>().HasKey(a => new { a.ProductId, a.CategoryId });

        base.OnModelCreating(builder);
    }
}
