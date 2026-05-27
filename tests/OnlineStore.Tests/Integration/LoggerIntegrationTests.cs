using OnlineStore.Infrastructure.Logging;

namespace OnlineStore.Tests.Integration;

public class LoggerIntegrationTests
{
    [Fact]
    public async Task Should_Write_Log_File()
    {
        var tempFile = Path.GetTempFileName();

        var logger = new FileLogger(tempFile);

        await logger.LogAsync("Test log");

        var text = await File.ReadAllTextAsync(tempFile);

        Assert.Contains("Test log", text);

        File.Delete(tempFile);
    }
}