namespace OnlineStore.Domain.Entities;

public class Cart
{
    private readonly List<CartItem> _items = new();

    public IReadOnlyCollection<CartItem> Items =>
        _items.AsReadOnly();

    public void AddProduct(Product product, int quantity)
    {
        var item = new CartItem(product, quantity);

        _items.Add(item);
    }

    public decimal CalculateTotal()
    {
        return _items.Sum(i => i.TotalPrice);
    }

    public bool IsEmpty()
    {
        return !_items.Any();
    }
}