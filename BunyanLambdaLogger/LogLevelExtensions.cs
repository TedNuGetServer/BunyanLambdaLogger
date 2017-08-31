// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging
{
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
      switch (value)
      {
        case LogLevel.Critical:
          return BunyanLambdaILogger.BunyanLogLevel.FATAL;

        case LogLevel.Debug:
          return BunyanLambdaILogger.BunyanLogLevel.DEBUG;

        case LogLevel.Error:
          return BunyanLambdaILogger.BunyanLogLevel.ERROR;

        case LogLevel.Information:
          return BunyanLambdaILogger.BunyanLogLevel.INFO;

        case LogLevel.Trace:
          return BunyanLambdaILogger.BunyanLogLevel.TRACE;

        case LogLevel.Warning:
          return BunyanLambdaILogger.BunyanLogLevel.WARN;

        default:
          // defaulting to Info based on Bunyan's default behaviour
          // "By default, log output is to stdout and at the 'info' level"
          // https://github.com/trentm/node-bunyan
          return BunyanLambdaILogger.BunyanLogLevel.INFO;
      }
    }
  }
}
