using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class ProductTests
{
    [Fact]
    public void Constructor_Should_Create_Product()
    {
        var product = new Product(
            "Laptop",
            50000,
            ProductCategory.Electronics,
            10);

        Assert.Equal("Laptop", product.Name);
    }

    [Fact]
    public void Constructor_Should_Throw_For_Invalid_Name()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                "",
                50000,
                ProductCategory.Electronics,
                10);
        });
    }

    [Fact]
    public void Constructor_Should_Throw_For_Invalid_Price()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product(
                "Laptop",
                0,
                ProductCategory.Electronics,
                10);
        });
    }
}