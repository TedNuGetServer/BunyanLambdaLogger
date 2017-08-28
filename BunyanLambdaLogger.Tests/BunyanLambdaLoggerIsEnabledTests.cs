using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BunyanLambdaLogger.Tests
{
  public class BunyanLambdaLoggerIsEnabledTests
  {
    [Fact]
    public void UsingWildcardsShouldNotLogForNone()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "None"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests));

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.False(logger.IsEnabled(LogLevel.Critical));
      Assert.False(logger.IsEnabled(LogLevel.Error));
      Assert.False(logger.IsEnabled(LogLevel.Warning));
      Assert.False(logger.IsEnabled(LogLevel.Information));
      Assert.False(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should not log critical");
      logger.LogError("Should not log error");
      logger.LogWarning("Should not log warning");
      logger.LogInformation("Should not log information");
      logger.LogDebug("Should not log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldOnlyLogForCritical()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Critical"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.False(logger.IsEnabled(LogLevel.Error));
      Assert.False(logger.IsEnabled(LogLevel.Warning));
      Assert.False(logger.IsEnabled(LogLevel.Information));
      Assert.False(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should not log error");
      logger.LogWarning("Should not log warning");
      logger.LogInformation("Should not log information");
      logger.LogDebug("Should not log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldLogForErrorAndAbove()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Error"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Error));
      Assert.False(logger.IsEnabled(LogLevel.Warning));
      Assert.False(logger.IsEnabled(LogLevel.Information));
      Assert.False(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should log error");
      logger.LogWarning("Should not log warning");
      logger.LogInformation("Should not log information");
      logger.LogDebug("Should not log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldLogForWarningAndAbove()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Warning"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Error));
      Assert.True(logger.IsEnabled(LogLevel.Warning));
      Assert.False(logger.IsEnabled(LogLevel.Information));
      Assert.False(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should log error");
      logger.LogWarning("Should log warning");
      logger.LogInformation("Should not log information");
      logger.LogDebug("Should not log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldLogForInformationAndAbove()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Information"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Error));
      Assert.True(logger.IsEnabled(LogLevel.Warning));
      Assert.True(logger.IsEnabled(LogLevel.Information));
      Assert.False(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should log error");
      logger.LogWarning("Should log warning");
      logger.LogInformation("Should log information");
      logger.LogDebug("Should not log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldLogForDebugAndAbove()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Debug"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Error));
      Assert.True(logger.IsEnabled(LogLevel.Warning));
      Assert.True(logger.IsEnabled(LogLevel.Information));
      Assert.True(logger.IsEnabled(LogLevel.Debug));
      Assert.False(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should log error");
      logger.LogWarning("Should log warning");
      logger.LogInformation("Should log information");
      logger.LogDebug("Should log debug");
      logger.LogTrace("Should not log trace");
    }

    [Fact]
    public void UsingWildcardsShouldLogForTraceAndAbove()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Trace"}
      };

      var logger = Logger.Create(conf, nameof(BunyanLambdaLoggerIsEnabledTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.None));
      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Error));
      Assert.True(logger.IsEnabled(LogLevel.Warning));
      Assert.True(logger.IsEnabled(LogLevel.Information));
      Assert.True(logger.IsEnabled(LogLevel.Debug));
      Assert.True(logger.IsEnabled(LogLevel.Trace));

      logger.LogCritical("Should log critical");
      logger.LogError("Should log error");
      logger.LogWarning("Should log warning");
      logger.LogInformation("Should log information");
      logger.LogDebug("Should log debug");
      logger.LogTrace("Should log trace");

      logger.LogCritical("Should log critical with {0}", "argument");
      logger.LogError("Should log error with {0}", "argument");
      logger.LogWarning("Should log warning with {0}", "argument");
      logger.LogInformation("Should log information with {0}", "argument");
      logger.LogDebug("Should log debug with {0}", "argument");
      logger.LogTrace("Should log trace with {0}", "argument");
    }
  }
}
