using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class OrderStatusTests
{
    private Order CreateOrder()
    {
        var customer = new Customer("Test", "test@mail.com");

        var product = new Product(
            "Phone",
            1000,
            ProductCategory.Electronics,
            10);

        var cart = new Cart();
        cart.AddProduct(product, 1);

        return new Order(customer, cart.Items.ToList());
    }

    [Fact]
    public void Should_Change_Status_To_Paid()
    {
        var order = CreateOrder();

        order.MarkAsPaid();

        Assert.Equal(OrderStatus.Paid, order.Status);
    }

    [Fact]
    public void Should_Change_Status_To_Shipped()
    {
        var order = CreateOrder();

        order.MarkAsPaid();
        order.MarkAsShipped();

        Assert.Equal(OrderStatus.Shipped, order.Status);
    }

    [Fact]
    public void Should_Not_Ship_Unpaid_Order()
    {
        var order = CreateOrder();

        Assert.Throws<InvalidOperationException>(() =>
        {
            order.MarkAsShipped();
        });
    }

    [Fact]
    public void Should_Not_Pay_Cancelled_Order()
    {
        var order = CreateOrder();

        order.Cancel();

        Assert.Throws<InvalidOperationException>(() =>
        {
            order.MarkAsPaid();
        });
    }
}