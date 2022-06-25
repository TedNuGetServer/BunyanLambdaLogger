// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging;

/// <summary>
///
/// </summary>
public static class LogLevelExtensions
{
  /// <summary>
  ///
  /// </summary>
  /// <param name="value"></param>
  /// <returns></returns>
  public static BunyanLambdaILogger.BunyanLogLevel ToBunyanLogLevel(this LogLevel value)
  {
    return value switch
    {
      LogLevel.Critical => BunyanLambdaILogger.BunyanLogLevel.FATAL,
      LogLevel.Debug => BunyanLambdaILogger.BunyanLogLevel.DEBUG,
      LogLevel.Error => BunyanLambdaILogger.BunyanLogLevel.ERROR,
      LogLevel.Information => BunyanLambdaILogger.BunyanLogLevel.INFO,
      LogLevel.Trace => BunyanLambdaILogger.BunyanLogLevel.TRACE,
      LogLevel.Warning => BunyanLambdaILogger.BunyanLogLevel.WARN,
      _ => BunyanLambdaILogger.BunyanLogLevel.INFO
    };
  }
}
