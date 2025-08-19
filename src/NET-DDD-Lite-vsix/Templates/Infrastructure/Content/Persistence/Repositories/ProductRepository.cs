using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Products;
using $safeprojectname$.Aggregates.Product;

namespace $rootnamespace$.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly YourAppDbContext _db;
    public ProductRepository(YourAppDbContext db) => _db = db;

    public System.Threading.Tasks.Task AddAsync(Product product, System.Threading.CancellationToken ct = default)
        => _db.Products.AddAsync(product, ct).AsTask();

    public System.Threading.Tasks.Task<Product?> GetAsync(System.Guid id, System.Threading.CancellationToken ct = default)
        => _db.Products.Include("_images").FirstOrDefaultAsync(x => x.Id == id, ct)!;

    public System.Threading.Tasks.Task SaveChangesAsync(System.Threading.CancellationToken ct = default)
        => _db.SaveChangesAsync(ct);
}
