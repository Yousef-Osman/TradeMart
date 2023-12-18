using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Net;
using TradeMart.API.Middlewares;
using TradeMart.Application.Interfaces.Repositories;
using TradeMart.Application.Models.Responses;
using TradeMart.Infrastructure.Data;
using TradeMart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//add services to the container.
var config = builder.Configuration;
var defaultConnectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
var redisConnectionString = config.GetConnectionString("RedisConnection") ?? throw new InvalidOperationException("Connection string not found.");

//add database files 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(defaultConnectionString));

//to add redis database
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.Parse(redisConnectionString, true);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy => policy
    .WithOrigins(config.GetSection("ClientUrl").Value)
    .AllowAnyHeader()
    .AllowAnyMethod()));

//to override api response for validation and use the class instead
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(e => e.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToList();

        return new BadRequestObjectResult(new ErrorResponse(statusCode: (int)HttpStatusCode.BadRequest, errors: errors));
    };
});

var app = builder.Build();

//global Exception handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

//to handle "Not Found Endpoint" redirect to "ErrorController" and pass status code {0}
app.UseStatusCodePagesWithReExecute("/errors/{0}");

//configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

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

    await context.Database.MigrateAsync();
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
