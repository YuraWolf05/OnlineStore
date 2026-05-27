using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Persistence;

namespace OnlineStore.Tests.Integration;

public class CorruptedJsonTests
{
    [Fact]
    public async Task Should_Handle_Corrupted_Json()
    {
        var tempFile = Path.GetTempFileName();

        await File.WriteAllTextAsync(tempFile, "INVALID_JSON");

        var store = new JsonDataStore<Product>(tempFile);

        var result = await store.LoadAsync();

        Assert.Empty(result);

        File.Delete(tempFile);
    }
}