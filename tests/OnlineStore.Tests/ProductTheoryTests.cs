using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class ProductTheoryTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(9999)]
    public void Product_Should_Accept_Valid_Prices(decimal price)
    {
        var product = new Product(
            "Phone",
            price,
            ProductCategory.Electronics,
            10);

        Assert.Equal(price, product.Price);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-500)]
    public void Product_Should_Reject_Invalid_Prices(decimal price)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                "Phone",
                price,
                ProductCategory.Electronics,
                10);
        });
    }
}