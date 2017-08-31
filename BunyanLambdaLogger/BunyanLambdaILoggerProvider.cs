using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging
{
  internal class BunyanLambdaILoggerProvider : ILoggerProvider
  {
    // Private fields
    private readonly LambdaLoggerOptions options;

    private readonly string applicationName;

    // Constructor
    public BunyanLambdaILoggerProvider(LambdaLoggerOptions options)
    {
      this.options = options ?? throw new ArgumentNullException(nameof(options));
    }

    // Constructor
    public BunyanLambdaILoggerProvider(LambdaLoggerOptions options, string applicationName)
    {
      this.options = options ?? throw new ArgumentNullException(nameof(options));
      this.applicationName = applicationName;
    }

    // Interface methods
    public ILogger CreateLogger(string categoryName)
    {
      return new BunyanLambdaILogger(categoryName, options, applicationName);
    }

    public void Dispose()
    {
    }
  }
}
