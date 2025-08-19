using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using $safeprojectname$.Products;
using $rootnamespace$.Persistence;
using $rootnamespace$.Persistence.Repositories;

namespace $rootnamespace$.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        var provider = cfg["Database:Provider"] ?? "SqlServer";
        var csSql = cfg["Database:ConnectionStrings:SqlServer"];
        var csPg  = cfg["Database:ConnectionStrings:Postgres"];

        services.AddDbContext<YourAppDbContext>(o =>
        {
            if (provider.Equals("Postgres", System.StringComparison.OrdinalIgnoreCase))
                o.UseNpgsql(csPg);
            else
                o.UseSqlServer(csSql);
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<$safeprojectname$.Abstractions.IUnitOfWork>(sp => sp.GetRequiredService<YourAppDbContext>());
        return services;
    }
}
