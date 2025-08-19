using $rootnamespace$.Aggregates.Product;

namespace $rootnamespace$.Products;

public interface IProductRepository
{
    System.Threading.Tasks.Task<Product?> GetAsync(System.Guid id, System.Threading.CancellationToken ct = default);
    System.Threading.Tasks.Task AddAsync(Product product, System.Threading.CancellationToken ct = default);
    System.Threading.Tasks.Task SaveChangesAsync(System.Threading.CancellationToken ct = default);
}
