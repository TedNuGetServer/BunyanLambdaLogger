namespace Microsoft.Extensions.Logging
{
  public static class LogLevelExtensions
  {
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

        // bunyan doesn't have a concept of "none" so we're just falling through
        // to the default... Blarg! Ho!
        case LogLevel.None:
        default:
          // defaulting to Info based on Bunyan's default behaviour
          // "By default, log output is to stdout and at the 'info' level"
          // https://github.com/trentm/node-bunyan
          return BunyanLambdaILogger.BunyanLogLevel.INFO;
      }
    }
  }
}
