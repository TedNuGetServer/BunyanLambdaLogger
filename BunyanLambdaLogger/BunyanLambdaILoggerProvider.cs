using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging
{
  internal class BunyanLambdaILoggerProvider : ILoggerProvider
  {
    // Private fields
    private readonly LambdaLoggerOptions options;

    private readonly string applicationName;

    private readonly string environment;

    // Constructor
    public BunyanLambdaILoggerProvider(LambdaLoggerOptions options)
    {
      this.options = options ?? throw new ArgumentNullException(nameof(options));
    }

    // Constructor
    public BunyanLambdaILoggerProvider(LambdaLoggerOptions options, string applicationName, string environment = null)
    {
      this.options = options ?? throw new ArgumentNullException(nameof(options));
      this.applicationName = applicationName;
      this.environment = environment;
    }

    // Interface methods
    public ILogger CreateLogger(string categoryName)
    {
      return new BunyanLambdaILogger(categoryName, options, applicationName, environment);
    }

    public void Dispose()
    {
    }
  }
}
