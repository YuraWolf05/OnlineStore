using OnlineStore.Domain.Enums;

namespace OnlineStore.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public Customer Customer { get; private set; }

    public List<CartItem> Items { get; private set; }

    public decimal TotalPrice { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public OrderStatus Status { get; private set; }

    public Order(
        Customer customer,
        List<CartItem> items)
    {
        if (customer == null)
        {
            throw new ArgumentException(
                "Customer is required");
        }

        if (items == null || items.Count == 0)
        {
            throw new ArgumentException(
                "Order must contain items");
        }

        if (items.Any(i => i.Quantity <= 0))
        {
            throw new ArgumentException(
                "Invalid quantity");
        }

        if (items.Any(i =>
                i.Product.StockQuantity < i.Quantity))
        {
            throw new InvalidOperationException(
                "Not enough stock");
        }

        Id = Guid.NewGuid();

        Customer = customer;

        Items = items;

        TotalPrice = items.Sum(i => i.TotalPrice);

        if (TotalPrice <= 0)
        {
            throw new ArgumentException(
                "Invalid total price");
        }

        CreatedAt = DateTime.UtcNow;

        Status = OrderStatus.Pending;

        ReduceProductStock();
    }

    public void MarkAsPaid()
    {
        if (Status == OrderStatus.Cancelled)
        {
            throw new InvalidOperationException(
                "Cancelled order cannot be paid");
        }

        Status = OrderStatus.Paid;
    }

    public void Ship()
    {
        if (Status != OrderStatus.Paid)
        {
            throw new InvalidOperationException(
                "Only paid order can be shipped");
        }

        Status = OrderStatus.Shipped;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
        {
            throw new InvalidOperationException(
                "Shipped order cannot be cancelled");
        }

        Status = OrderStatus.Cancelled;
    }

    private void ReduceProductStock()
    {
        foreach (var item in Items)
        {
            item.Product.ReduceStock(
                item.Quantity);
        }
    }
}