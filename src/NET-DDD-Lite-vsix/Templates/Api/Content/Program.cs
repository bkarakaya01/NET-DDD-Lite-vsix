using Microsoft.Extensions.Configuration;
using $safeprojectname$.Configuration; // Application AddApplication
using $safeprojectname$.Features.Products.Commands.CreateProduct;
using $safeprojectname$.Features.Products.Commands.AddProductImage;
using $safeprojectname$.Features.Products.Queries.GetProduct;
using $safeprojectname$.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapPost("/products", async (CreateProductCommand cmd, CreateProductHandler h, System.Threading.CancellationToken ct) =>
{
    var id = await h.Handle(cmd, ct);
    return Results.Created($"/products/{id}", new { id });
});

app.MapPost("/products/{id:guid}/images", async (System.Guid id, string fileName, AddProductImageHandler h, System.Threading.CancellationToken ct) =>
{
    await h.Handle(new AddProductImageCommand(id, fileName), ct);
    return Results.NoContent();
});

app.MapGet("/products/{id:guid}", async (System.Guid id, GetProductHandler h, System.Threading.CancellationToken ct) =>
{
    var dto = await h.Handle(new GetProductQuery(id), ct);
    return dto is null ? Results.NotFound() : Results.Ok(dto);
});

await app.UseMigrationsAndSeedAsync();
app.Run();
