using OnlineStore.Domain.Enums;

namespace OnlineStore.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public Customer Customer { get; private set; }

    public List<CartItem> Items { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public decimal TotalPrice =>
        Items.Sum(i => i.TotalPrice);

    public Order(
        Customer customer,
        List<CartItem> items)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (items == null || !items.Any())
        {
            throw new ArgumentException(
                "Order must contain items.");
        }

        Id = Guid.NewGuid();

        Customer = customer;

        Items = items;

        Status = OrderStatus.Pending;

        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsPaid()
    {
        if (Status == OrderStatus.Cancelled)
        {
            throw new InvalidOperationException(
                "Cancelled order cannot be paid.");
        }

        if (Status != OrderStatus.Pending)
        {
            throw new InvalidOperationException(
                "Only pending orders can be paid.");
        }

        Status = OrderStatus.Paid;
    }

    public void MarkAsShipped()
    {
        if (Status != OrderStatus.Paid)
        {
            throw new InvalidOperationException(
                "Only paid orders can be shipped.");
        }

        Status = OrderStatus.Shipped;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
        {
            throw new InvalidOperationException(
                "Shipped order cannot be cancelled.");
        }

        Status = OrderStatus.Cancelled;
    }
}