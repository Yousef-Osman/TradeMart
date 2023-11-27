using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Infrastructure.Data;
using TradeMart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    //await context.Database.MigrateAsync();
    //await DatabaseSeeder.SeedRolesAsync(roleManager);
    //await DatabaseSeeder.SeedSuperAdminAsync(userManager, roleManager);
    await DatabaseSeeder.SeedProductDataAsync(context);

    logger.LogInformation("Data seeded successfully");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during seeding data");
}

app.Run();
