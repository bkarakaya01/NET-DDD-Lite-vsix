namespace $rootnamespace$.Aggregates.Product;

public class ProductImage
{
    public System.Guid Id { get; private set; }
    public string FileName { get; private set; }

    private ProductImage() { }
    internal ProductImage(string fileName)
    {
        Id = System.Guid.NewGuid();
        FileName = fileName;
    }
}
