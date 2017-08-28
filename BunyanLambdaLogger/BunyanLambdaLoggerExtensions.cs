using Microsoft.Extensions.Logging.Internal;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Microsoft.Extensions.Logging
{
  /// <summary>ILogger extension methods for common scenarios.</summary>
  public static class LoggerExtensions
  {
    private static readonly Func<object, Exception, string> _messageFormatter = MessageFormatter;

    #region LogCritical

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogCritical(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Critical, eventId: 0, state: dataSet, exception: null,
        formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogCritical(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Critical, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    #region LogWarning

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogWarning(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Warning, eventId: 0, state: dataSet, exception: null, formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogWarning(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Warning, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    #region LogInformation

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogInformation(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Information, eventId: 0, state: dataSet, exception: null,
        formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogInformation(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Information, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    #region LogDebug

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogDebug(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Debug, eventId: 0, state: dataSet, exception: null, formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogDebug(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Debug, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    #region LogTrace

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogTrace(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Trace, eventId: 0, state: dataSet, exception: null, formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogTrace(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Trace, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    #region LogError

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogError(this ILogger logger, string message, object data, params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Critical, eventId: 0, state: dataSet, exception: null,
        formatter: _messageFormatter);
    }

    /// <summary>Formats and writes an informational log message.</summary>
    /// <param name="logger">The <see cref="T:Microsoft.Extensions.Logging.ILogger" /> to write to.</param>
    /// <param name="message">Format string of the log message.</param>
    /// <param name="exception">The exception to log.</param>
    /// <param name="data">An object to attach to the log output</param>
    /// <param name="args">param arguments</param>
    public static void LogError(this ILogger logger, string message, object data, Exception exception,
      params object[] args)
    {
      if (logger == null) throw new ArgumentNullException(nameof(logger));

      var dataSet = CreateDataSet(message, data, args);

      logger.Log(logLevel: LogLevel.Critical, eventId: 0, state: dataSet, exception: exception,
        formatter: _messageFormatter);
    }

    #endregion

    private static JObject CreateDataSet(string message, object data, object[] args)
    {
      if (data != null && data.GetType().Name.ToLower() == "string")
      {
        args = args ?? new object[] { };
        args = new[] {data}.Concat(args).ToArray();
        data = null;
      }

      var dataSet = JObject.FromObject(data ?? new { });
      dataSet.Add("msg", new FormattedLogValues(message, args).ToString());
      return dataSet;
    }

    private static string MessageFormatter(object state, Exception error)
    {
      return state.ToString();
    }
  }
}
