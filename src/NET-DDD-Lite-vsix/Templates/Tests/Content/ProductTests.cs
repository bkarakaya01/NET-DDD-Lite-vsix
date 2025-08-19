using $safeprojectname$.Aggregates.Product;
using $safeprojectname$.ValueObjects;
using FluentAssertions;
using Xunit;

public class ProductTests
{
    [Fact]
    public void Create_Product_Should_Set_Name_And_Price()
    {
        var p = Product.Create("Klasid Model X", Money.Of(100, "TRY"));
        p.Name.Should().Be("Klasid Model X");
        p.Price.Amount.Should().Be(100);
        p.Price.Currency.Should().Be("TRY");
    }
}
