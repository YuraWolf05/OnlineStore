namespace OnlineStore.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }

    public Customer Customer { get; private set; }

    public List<CartItem> Items { get; private set; }

    public decimal TotalPrice { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Order(Customer customer, List<CartItem> items)
    {
        if (items == null || !items.Any())
            throw new ArgumentException("Order must contain items");

        Id = Guid.NewGuid();

        Customer = customer;

        Items = items;

        TotalPrice = items.Sum(i => i.TotalPrice);

        CreatedAt = DateTime.UtcNow;
    }
}