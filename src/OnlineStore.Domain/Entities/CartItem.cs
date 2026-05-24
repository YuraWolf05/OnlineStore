namespace OnlineStore.Domain.Entities;

public class CartItem
{
    public Product Product { get; private set; }

    public int Quantity { get; private set; }

    public decimal TotalPrice => Product.Price * Quantity;

    public CartItem(Product product, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        Product = product;
        Quantity = quantity;
    }
}