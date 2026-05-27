using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class OrderTests
{
    [Fact]
    public void Order_Should_Be_Created()
    {
        var customer = new Customer("Test", "test@mail.com");

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        var cart = new Cart();
        cart.AddProduct(product, 1);

        var order = new Order(customer, cart.Items.ToList());

        Assert.Equal(OrderStatus.Pending, order.Status);
    }

    [Fact]
    public void Order_Should_Calculate_Total()
    {
        var customer = new Customer("Test", "test@mail.com");

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        var cart = new Cart();
        cart.AddProduct(product, 2);

        var order = new Order(customer, cart.Items.ToList());

        Assert.Equal(2000, order.TotalPrice);
    }

    [Fact]
    public void Should_Throw_When_No_Items()
    {
        var customer = new Customer("Test", "test@mail.com");

        Assert.Throws<ArgumentException>(() =>
        {
            new Order(customer, new List<CartItem>());
        });
    }
}