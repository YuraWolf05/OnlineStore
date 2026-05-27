using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Services;

public class OrderService
{
    private readonly IRepository<Order, Guid>
        _orderRepository;

    public OrderService(
        IRepository<Order, Guid> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Order CreateOrder(
        Customer customer,
        Cart cart)
    {
        if (cart.IsEmpty())
        {
            throw new InvalidOperationException(
                "Cart is empty");
        }

        var order = new Order(
            customer,
            cart.Items.ToList());

        _orderRepository.Add(order);

        return order;
    }

    public void PayOrder(Guid orderId)
    {
        var order =
            _orderRepository.GetById(orderId);

        if (order == null)
        {
            throw new InvalidOperationException(
                "Order not found");
        }

        order.MarkAsPaid();

        _orderRepository.Update(order);
    }

    public void ShipOrder(Guid orderId)
    {
        var order =
            _orderRepository.GetById(orderId);

        if (order == null)
        {
            throw new InvalidOperationException(
                "Order not found");
        }

        order.Ship();

        _orderRepository.Update(order);
    }

    public void CancelOrder(Guid orderId)
    {
        var order =
            _orderRepository.GetById(orderId);

        if (order == null)
        {
            throw new InvalidOperationException(
                "Order not found");
        }

        order.Cancel();

        _orderRepository.Update(order);
    }

    public IReadOnlyCollection<Order> GetOrders()
    {
        return _orderRepository.GetAll();
    }
}