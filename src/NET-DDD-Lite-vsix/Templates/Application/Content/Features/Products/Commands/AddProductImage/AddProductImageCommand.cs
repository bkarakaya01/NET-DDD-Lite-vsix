using $rootnamespace$.Products;

namespace $rootnamespace$.Features.Products.Commands.AddProductImage;

public sealed record AddProductImageCommand(System.Guid ProductId, string FileName);

public sealed class AddProductImageHandler
{
    private readonly IProductRepository _repo;

    public AddProductImageHandler(IProductRepository repo) => _repo = repo;

    public async System.Threading.Tasks.Task Handle(AddProductImageCommand cmd, System.Threading.CancellationToken ct)
    {
        var p = await _repo.GetAsync(cmd.ProductId, ct) ?? throw new System.Collections.Generic.KeyNotFoundException("Product not found");
        p.AddImage(cmd.FileName);
        await _repo.SaveChangesAsync(ct);
    }
}
