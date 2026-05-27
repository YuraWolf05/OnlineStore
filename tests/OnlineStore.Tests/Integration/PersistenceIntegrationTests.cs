using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using OnlineStore.Infrastructure.Persistence;

namespace OnlineStore.Tests.Integration;

public class PersistenceIntegrationTests
{
    [Fact]
    public async Task Should_Save_And_Load_Products()
    {
        var tempFile = Path.GetTempFileName();

        var store = new JsonDataStore<Product>(tempFile);

        var products = new List<Product>
        {
            new Product("Phone", 1000, ProductCategory.Electronics, 10)
        };

        await store.SaveAsync(products);

        var loaded = await store.LoadAsync();

        Assert.Single(loaded);

        File.Delete(tempFile);
    }

    [Fact]
    public async Task Should_Return_Empty_When_File_Not_Exists()
    {
        var tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");

        var store = new JsonDataStore<Product>(tempFile);

        var result = await store.LoadAsync();

        Assert.Empty(result);
    }
}