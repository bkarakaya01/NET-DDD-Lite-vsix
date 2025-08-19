using $rootnamespace$.ValueObjects;
using System.Collections.Generic;

namespace $rootnamespace$.Aggregates.Product;

public class Product
{
    private readonly List<ProductImage> _images = new();

    public System.Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public Money Price { get; private set; } = default!;
    public System.Collections.Generic.IReadOnlyCollection<ProductImage> Images => _images.AsReadOnly();

    private Product() { }
    private Product(string name, Money price)
    {
        Id = System.Guid.NewGuid();
        Rename(name);
        ChangePrice(price);
    }

    public static Product Create(string name, Money price) => new(name, price);

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new System.ArgumentException("Name required.");
        Name = name.Trim();
    }

    public void ChangePrice(Money newPrice)
    {
        Price = newPrice ?? throw new System.ArgumentNullException(nameof(newPrice));
    }

    public void AddImage(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName)) throw new System.ArgumentException("File required.");
        _images.Add(new ProductImage(fileName));
    }
}
