using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Extensions;

public static class ProductFilterExtensions
{
    public static IEnumerable<Product> Filter(
        this IEnumerable<Product> products,
        Func<Product, bool> predicate)
    {
        return products.Where(predicate);
    }

    public static IEnumerable<Product> ExpensiveProducts(
        this IEnumerable<Product> products,
        decimal minPrice)
    {
        return products.Where(p => p.Price >= minPrice);
    }

    public static IEnumerable<Product> InStock(
        this IEnumerable<Product> products)
    {
        return products.Where(p => p.StockQuantity > 0);
    }
}