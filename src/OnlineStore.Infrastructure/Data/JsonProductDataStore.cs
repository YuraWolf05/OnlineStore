using System.Text.Json;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Data;

public class JsonProductDataStore
    : IDataStore<Product>
{
    private readonly string _filePath =
        "products.json";

    public async Task<IReadOnlyCollection<Product>>
        LoadAsync(
            CancellationToken cancellationToken = default)
    {
        try
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            await using var stream =
                File.OpenRead(_filePath);

            var products =
                await JsonSerializer.DeserializeAsync<List<Product>>(
                    stream,
                    cancellationToken: cancellationToken);

            return products ?? new List<Product>();
        }
        catch (JsonException)
        {
            Console.WriteLine(
                "JSON file is corrupted");

            return new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Load error: {ex.Message}");

            return new List<Product>();
        }
    }

    public async Task SaveAsync(
        IReadOnlyCollection<Product> items,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await using var stream =
                File.Create(_filePath);

            await JsonSerializer.SerializeAsync(
                stream,
                items,
                cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Save error: {ex.Message}");
        }
    }
}