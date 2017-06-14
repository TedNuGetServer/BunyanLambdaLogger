using System;

namespace Microsoft.Extensions.Logging
{
  public partial class BunyanLambdaILogger : ILogger
  {
    private readonly string categoryName;

    private readonly string applicationName;

    private const string DEFAULT_CATEGORY_NAME = "Default";

    public BunyanLambdaILogger(string categoryName)
    {
      this.categoryName = string.IsNullOrEmpty(categoryName) ? DEFAULT_CATEGORY_NAME : categoryName;
    }

    public BunyanLambdaILogger(string categoryName, string applicationName) : this(categoryName)
    {
      this.applicationName = applicationName;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      // No support for scopes at this point
      // https://docs.asp.net/en/latest/fundamentals/logging.html#scopes
      return new NoOpDisposable();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
      if (formatter == null)
      {
        throw new ArgumentNullException(nameof(formatter));
      }

      var text = formatter.Invoke(state, exception);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      throw new NotImplementedException();
    }

    private class NoOpDisposable : IDisposable
    {
      public void Dispose()
      {
      }
    }
  }
}
