using OnlineStore.Domain.Enums;

namespace OnlineStore.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public ProductCategory Category { get; private set; }

    public int StockQuantity { get; private set; }

    public Product(
        string name,
        decimal price,
        ProductCategory category,
        int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if (stockQuantity < 0)
            throw new ArgumentException("Stock cannot be negative");

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Category = category;
        StockQuantity = stockQuantity;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive");

        if (quantity > StockQuantity)
            throw new InvalidOperationException("Not enough stock");

        StockQuantity -= quantity;
    }
}