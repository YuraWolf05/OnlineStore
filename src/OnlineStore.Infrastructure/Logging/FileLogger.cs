namespace OnlineStore.Infrastructure.Logging;

public class FileLogger
{
    private readonly string _path;

    public FileLogger(string path)
    {
        _path = path;
    }

    public async Task LogAsync(string message)
    {
        var line =
            $"[{DateTime.Now}] {message}{Environment.NewLine}";

        await File.AppendAllTextAsync(_path, line);
    }
}