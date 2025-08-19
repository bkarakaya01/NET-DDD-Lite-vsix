using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using $safeprojectname$.Aggregates.Product;
using $safeprojectname$.ValueObjects;

namespace $rootnamespace$.Startup;

public static class DbInitializer
{
    public static async System.Threading.Tasks.Task UseMigrationsAndSeedAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var cfg = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var db  = scope.ServiceProvider.GetRequiredService<Persistence.YourAppDbContext>();

        await db.Database.MigrateAsync();

        var seed = bool.TryParse(cfg["Database:Seed"], out var v) ? v : false;
        if (!seed) return;

        if (!await db.Products.AnyAsync())
        {
            var p = Aggregates.Product.Product.Create("Klasid Model X", Money.Of(1299.90m, "TRY"));
            p.AddImage("front.jpg");
            p.AddImage("side.jpg");
            await db.Products.AddAsync(p);
            await db.SaveChangesAsync();
        }
    }
}
