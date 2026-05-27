using OnlineStore.Application.Services;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using OnlineStore.Infrastructure.Repositories;

namespace OnlineStore.Tests;

public class ServiceTests
{
    [Fact]
    public void Should_Create_Order_From_Cart()
    {
        var repo = new InMemoryOrderRepository();
        var service = new OrderService(repo);

        var customer = new Customer("Test", "test@mail.com");

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        var cart = new Cart();
        cart.AddProduct(product, 1);

        var order = service.CreateOrder(customer, cart);

        Assert.NotNull(order);
    }

    [Fact]
    public void Should_Throw_When_Cart_Is_Empty()
    {
        var repo = new InMemoryOrderRepository();
        var service = new OrderService(repo);

        var customer = new Customer("Test", "test@mail.com");

        var cart = new Cart();

        Assert.Throws<InvalidOperationException>(() =>
        {
            service.CreateOrder(customer, cart);
        });
    }
}