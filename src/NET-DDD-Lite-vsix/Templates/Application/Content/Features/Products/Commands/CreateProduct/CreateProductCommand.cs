using $rootnamespace$.Abstractions;
using $rootnamespace$.Products;
using $rootnamespace$.Aggregates.Product;
using $rootnamespace$.ValueObjects;

namespace $rootnamespace$.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(string Name, decimal Price, string Currency);

public sealed class CreateProductHandler
{
    private readonly IProductRepository _repo;
    private readonly IUnitOfWork _uow;

    public CreateProductHandler(IProductRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async System.Threading.Tasks.Task<System.Guid> Handle(CreateProductCommand cmd, System.Threading.CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(cmd.Name)) throw new System.ArgumentException("Name required.");
        if (cmd.Price <= 0) throw new System.ArgumentOutOfRangeException(nameof(cmd.Price));

        var product = Product.Create(cmd.Name, Money.Of(cmd.Price, cmd.Currency));
        await _repo.AddAsync(product, ct);
        await _uow.SaveChangesAsync(ct);
        return product.Id;
    }
}
