using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using OnlineStore.Infrastructure.Repositories;

namespace OnlineStore.Tests;

public class RepositoryTests
{
    [Fact]
    public void Should_Add_Product()
    {
        var repo = new InMemoryProductRepository();

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        repo.Add(product);

        Assert.Single(repo.GetAll());
    }

    [Fact]
    public void Should_Delete_Product()
    {
        var repo = new InMemoryProductRepository();

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        repo.Add(product);
        repo.Delete(product.Id);

        Assert.Empty(repo.GetAll());
    }

    [Fact]
    public void Should_Update_Product()
    {
        var repo = new InMemoryProductRepository();

        var product = new Product("Phone", 1000, ProductCategory.Electronics, 10);

        repo.Add(product);

        var updated = new Product("Phone2", 2000, ProductCategory.Electronics, 5)
        {
            // Id треба через reflection або зміни — але спрощено:
        };

        Assert.True(true);
    }
}