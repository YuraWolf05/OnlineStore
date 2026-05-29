using OnlineStore.Application.Extensions;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;

namespace OnlineStore.Tests;

public class ProductFilterExtensionsTests
{
    [Fact]
    public void ExpensiveProducts_ShouldReturnOnlyExpensive()
    {
        var products = new List<Product>
        {
            new Product(
                "Phone",
                500,
                ProductCategory.Electronics,
                5),

            new Product(
                "Mouse",
                20,
                ProductCategory.Electronics,
                10)
        };

        var result = products.ExpensiveProducts(100).ToList();

        Assert.Single(result);
        Assert.Equal("Phone", result[0].Name);
    }

    [Fact]
    public void InStock_ShouldReturnAvailableProducts()
    {
        var products = new List<Product>
        {
            new Product(
                "Phone",
                500,
                ProductCategory.Electronics,
                5),

            new Product(
                "Laptop",
                1000,
                ProductCategory.Electronics,
                0)
        };

        var result = products.InStock().ToList();

        Assert.Single(result);
        Assert.Equal("Phone", result[0].Name);
    }
}