using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class CartNegativeTests
{
    [Fact]
    public void Should_Not_Add_Negative_Quantity()
    {
        var cart = new Cart();

        var product = new Product(
            "Phone",
            1000,
            ProductCategory.Electronics,
            10);

        Assert.Throws<ArgumentException>(() =>
        {
            cart.AddProduct(product, -1);
        });
    }

    [Fact]
    public void Should_Not_Add_Zero_Quantity()
    {
        var cart = new Cart();

        var product = new Product(
            "Phone",
            1000,
            ProductCategory.Electronics,
            10);

        Assert.Throws<ArgumentException>(() =>
        {
            cart.AddProduct(product, 0);
        });
    }
}