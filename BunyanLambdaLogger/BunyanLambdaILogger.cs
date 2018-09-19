using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging
{
  /// <summary>
  ///
  /// </summary>
  public partial class BunyanLambdaILogger : ILogger
  {
    private readonly string categoryName;
    private readonly LambdaLoggerOptions options;

    private readonly string applicationName;

    private readonly string hostname;

    private readonly string environment;

    private const string DEFAULT_CATEGORY_NAME = "Default";

    /// <summary>
    ///
    /// </summary>
    /// <param name="categoryName"></param>
    /// <param name="options"></param>
    public BunyanLambdaILogger(string categoryName, LambdaLoggerOptions options)
    {
      this.categoryName = string.IsNullOrEmpty(categoryName) ? DEFAULT_CATEGORY_NAME : categoryName;
      this.options = options;
    }

    /// <summary>
    /// </summary>
    /// <param name="categoryName"></param>
    /// <param name="options"></param>
    /// <param name="applicationName"></param>
    /// <param name="environment"></param>
    public BunyanLambdaILogger(string categoryName, LambdaLoggerOptions options, string applicationName, string environment = null)
      : this(categoryName, options)
    {
      this.applicationName = applicationName;
      this.environment = environment;
      hostname = hostname = Dns.GetHostName();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="state"></param>
    /// <typeparam name="TState"></typeparam>
    /// <returns></returns>
    public IDisposable BeginScope<TState>(TState state)
    {
      // No support for scopes at this point
      // https://docs.asp.net/en/latest/fundamentals/logging.html#log-scopes
      return new NoOpDisposable();
    }

    ///  <summary>
    ///  </summary>
    ///  <param name="logLevel"></param>
    ///  <returns></returns>
    public bool IsEnabled(LogLevel logLevel)
    {
      return (options.Filter == null || options.Filter(categoryName, logLevel));
    }

    /// <summary>
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="eventId"></param>
    /// <param name="state"></param>
    /// <param name="exception"></param>
    /// <param name="formatter"></param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
      Func<TState, Exception, string> formatter)
    {
      if (!IsEnabled(logLevel)) return;

      if (formatter == null) throw new ArgumentNullException(nameof(formatter));

      dynamic message = new JObject();

      if (applicationName != null) message.name = applicationName;

      if (environment != null) message.env = environment;

      if (options.IncludeLogLevel) message.level = logLevel.ToBunyanLogLevel();

      if (options.IncludeCategory) message.category_name = categoryName;

      message.pid = Process.GetCurrentProcess().Id;

      message.hostname = hostname;

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
      else
      {
        message.msg = formatter.Invoke(state, exception);
      }

      if (options.IncludeNewline)
      {
      }

      message.time = DateTime.UtcNow;

      if (exception != null) message.err = exception.ToString();

      if (eventId.Id != 0)
      {
        message.event_id = eventId.Id;
        message.event_name = eventId.Name;
      }

      message.v = 0;

      string finalText;
      try
      {
        finalText = JsonConvert.SerializeObject(message, Formatting.None, new JsonSerializerSettings
        {
          NullValueHandling = NullValueHandling.Ignore,
        });
      }
#pragma warning disable 168
      catch (Exception e)
#pragma warning restore 168
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
