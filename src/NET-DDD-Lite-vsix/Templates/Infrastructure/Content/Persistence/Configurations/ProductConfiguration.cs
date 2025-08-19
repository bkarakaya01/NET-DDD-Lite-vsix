using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Aggregates.Product;

namespace $rootnamespace$.Persistence.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> b)
    {
        b.ToTable("Products");
        b.HasKey(p => p.Id);
        b.Property(p => p.Name).HasMaxLength(200).IsRequired();

        b.OwnsOne(p => p.Price, price =>
        {
            price.Property(m => m.Amount).HasColumnName("PriceAmount").HasPrecision(18,2);
            price.Property(m => m.Currency).HasColumnName("PriceCurrency").HasMaxLength(3).IsRequired();
        });

        var nav = b.Metadata.FindNavigation(nameof(Product.Images))!;
        nav.SetPropertyAccessMode(PropertyAccessMode.Field);
        b.OwnsMany(typeof(ProductImage), "_images", img =>
        {
            img.ToTable("ProductImages");
            img.WithOwner().HasForeignKey("ProductId");
            img.Property<System.Guid>("Id");
            img.HasKey("Id");
            img.Property<string>("FileName").HasMaxLength(300).IsRequired();
        });
    }
}
