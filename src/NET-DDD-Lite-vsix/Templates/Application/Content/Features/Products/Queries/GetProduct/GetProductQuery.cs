using $rootnamespace$.Products;

namespace $rootnamespace$.Features.Products.Queries.GetProduct;

public sealed record ProductDto(System.Guid Id, string Name, decimal Price, string Currency, System.Collections.Generic.IReadOnlyList<string> Images);
public sealed record GetProductQuery(System.Guid Id);

public sealed class GetProductHandler
{
    private readonly IProductRepository _repo;
    public GetProductHandler(IProductRepository repo) => _repo = repo;

    public async System.Threading.Tasks.Task<ProductDto?> Handle(GetProductQuery q, System.Threading.CancellationToken ct)
    {
        var p = await _repo.GetAsync(q.Id, ct);
        if (p is null) return null;

        return new ProductDto(
            p.Id,
            p.Name,
            p.Price.Amount,
            p.Price.Currency,
            p.Images.Select(i => i.FileName).ToList()
        );
    }
}
