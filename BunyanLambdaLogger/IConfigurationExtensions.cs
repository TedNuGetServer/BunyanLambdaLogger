using Microsoft.Extensions.Logging;
using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration;

/// <summary>IConfiguration extensions</summary>
public static class IConfigurationExtensions
{
  /// <summary>
  /// Creates LambdaLoggerOptions instance from "Lambda.Logging" section of the
  /// specified configuration.
  /// </summary>
  /// <param name="configuration">Configuration to get settings from.</param>
  /// <returns></returns>
  [CLSCompliant(false)]
  public static LambdaLoggerOptions GetLambdaLoggerOptions(this IConfiguration configuration)
  {
    if (configuration == null) throw new ArgumentNullException(nameof(configuration));

    return new LambdaLoggerOptions(configuration);
  }

  /// <summary>
  /// Creates LambdaLoggerOptions instance from the specified subsection of the
  /// configuration section.
  /// </summary>
  /// <param name="configuration">Configuration to get settings from.</param>
  /// <param name="loggingSectionName">Name of section from which to get configuration data.</param>
  /// <returns></returns>
  [CLSCompliant(false)]
  public static LambdaLoggerOptions GetLambdaLoggerOptions(this IConfiguration configuration, string loggingSectionName)
  {
    if (configuration == null) throw new ArgumentNullException(nameof(configuration));
    if (string.IsNullOrEmpty(loggingSectionName)) throw new ArgumentNullException(nameof(loggingSectionName));

    return new LambdaLoggerOptions(configuration, loggingSectionName);
  }
}
