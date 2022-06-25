using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging;

/// <summary>
///
/// </summary>
public class BunyanLambdaILoggerProvider : ILoggerProvider
{
  private readonly LambdaLoggerOptions options;

  private readonly string applicationName;

  private readonly string environment;

  /// <summary>
  ///
  /// </summary>
  /// <param name="options"></param>
  public BunyanLambdaILoggerProvider(LambdaLoggerOptions options)
  {
    this.options = options ?? throw new ArgumentNullException(nameof(options));
  }

  /// <summary>
  ///
  /// </summary>
  /// <param name="options"></param>
  /// <param name="applicationName"></param>
  /// <param name="environment"></param>
  public BunyanLambdaILoggerProvider(LambdaLoggerOptions options, string applicationName, string environment = null)
  {
    this.options = options ?? throw new ArgumentNullException(nameof(options));
    this.applicationName = applicationName;
    this.environment = environment;
  }

  /// <summary>
  ///
  /// </summary>
  /// <param name="categoryName"></param>
  /// <returns></returns>
  public ILogger CreateLogger(string categoryName)
  {
    return new BunyanLambdaILogger(categoryName, options, applicationName, environment);
  }

  /// <summary>
  ///
  /// </summary>
  public void Dispose()
  {
    GC.SuppressFinalize(this);
  }
}
