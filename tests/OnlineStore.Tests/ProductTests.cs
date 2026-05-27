using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class ProductTests
{
    [Fact]
    public void Product_Should_Be_Created_Correctly()
    {
        var p = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        Assert.Equal("Phone", p.Name);
        Assert.Equal(1000, p.Price);
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Invalid()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product("", 1000, ProductCategory.Electronics, 10);
        });
    }

    [Fact]
    public void Should_Throw_When_Price_Is_Invalid()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Product("Phone", 0, ProductCategory.Electronics, 10);
        });
    }
}