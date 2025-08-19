using Microsoft.Extensions.DependencyInjection;

namespace $rootnamespace$.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // register handlers here (you can use Scrutor to scan later)
        return services;
    }
}
