using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Microsoft.Extensions.Logging
{
  public partial class BunyanLambdaILogger : ILogger, ILogger<object>
  {
    private readonly string categoryName;
    private readonly LambdaLoggerOptions options;

    internal readonly string applicationName;

    private const string DEFAULT_CATEGORY_NAME = "Default";

    public BunyanLambdaILogger(string categoryName, LambdaLoggerOptions options)
    {
      this.categoryName = string.IsNullOrEmpty(categoryName) ? DEFAULT_CATEGORY_NAME : categoryName;
      this.options = options;
    }

    public BunyanLambdaILogger(string categoryName, LambdaLoggerOptions options, string applicationName)
      : this(categoryName, options)
    {
      this.applicationName = applicationName;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      // No support for scopes at this point
      // https://docs.asp.net/en/latest/fundamentals/logging.html#log-scopes
      return new NoOpDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return (options.Filter == null || options.Filter(categoryName, logLevel));
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
      Func<TState, Exception, string> formatter)
    {
      if (!IsEnabled(logLevel)) return;

      if (formatter == null) throw new ArgumentNullException(nameof(formatter));

      dynamic message = new JObject();

      if (applicationName != null) message.name = applicationName;

      if (options.IncludeLogLevel) message.level = logLevel.ToBunyanLogLevel();

      if (options.IncludeCategory) message.category_name = categoryName;

      message.pid = Process.GetCurrentProcess().Id;

      message.hostname = Environment.GetEnvironmentVariable("COMPUTERNAME") ??
                         Environment.GetEnvironmentVariable("HOSTNAME") ??
                         Process.GetCurrentProcess().MachineName;

      if (state.GetType().Name.ToLower() == "jobject")
      {
        using (var enumerator = (state as JObject)?.GetEnumerator())
        {
          if (enumerator == null) return;
          while (enumerator.MoveNext())
          {
            var current = enumerator.Current;
            message[current.Key.ToLower()] = current.Value;
          }
        }
      }

      if (options.IncludeNewline)
      {
      }

      message.time = DateTime.UtcNow;

      if (exception != null) message.err = JObject.FromObject(exception);

      if (eventId.Id != 0) message.event_id = eventId;

      string finalText;
      try
      {
        finalText = JsonConvert.SerializeObject(message, Formatting.None, new JsonSerializerSettings
        {
          NullValueHandling = NullValueHandling.Ignore,
        });
      }
      catch (Exception e)
      {
        return; // suppressing error here is intentional
      }

      Amazon.Lambda.Core.LambdaLogger.Log(finalText);
    }

    private class NoOpDisposable : IDisposable
    {
      public void Dispose()
      {
      }
    }
  }
}
