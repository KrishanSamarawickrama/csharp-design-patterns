using System.Text;
using Microsoft.Extensions.Logging;

var logger = new FileLogger<Program>("Log.txt");

for (int i = 1; i <= 10; i++)
{
    logger.LogDebug($"{i} - This is a new log message. at {DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss t z")}");
}


public class FileLogger<T> : FileStream, ILogger
{
    public FileLogger(string path) : base(path, FileMode.Append)
    {
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(state?.ToString() + "\n");

        Write(byteArray, 0, byteArray.Length);
        Flush();
    }
}