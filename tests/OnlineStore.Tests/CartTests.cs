using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class CartTests
{
    [Fact]
    public void Add_To_Cart_Should_Work()
    {
        var cart = new Cart();

        var product = new Product("Mouse", 500, ProductCategory.Electronics, 10);

        cart.AddProduct(product, 2);

        Assert.Single(cart.Items);
    }

    [Fact]
    public void Cart_Total_Should_Be_Correct()
    {
        var cart = new Cart();

        var product = new Product("Mouse", 500, ProductCategory.Electronics, 10);

        cart.AddProduct(product, 2);

        Assert.Equal(1000, cart.CalculateTotal());
    }

    [Fact]
    public void Empty_Cart_Should_Be_Empty()
    {
        var cart = new Cart();

        Assert.True(cart.IsEmpty());
    }
}