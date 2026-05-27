using System.Text.Json;

namespace OnlineStore.Infrastructure.Persistence;

public class JsonDataStore<T>
{
    private readonly string _filePath;

    public JsonDataStore(string filePath)
    {
        _filePath = filePath;
    }

    public async Task SaveAsync(IReadOnlyCollection<T> items)
    {
        var json = JsonSerializer.Serialize(items,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task<IReadOnlyCollection<T>> LoadAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<T>();
        }

        try
        {
            var json = await File.ReadAllTextAsync(_filePath);

            var result = JsonSerializer.Deserialize<List<T>>(json);

            return result ?? new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }
}