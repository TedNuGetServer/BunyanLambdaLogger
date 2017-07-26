using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit;

namespace BunyanLambdaLogger.Tests
{
  public class BunyanLambdaILoggerTests
  {
    public ILogger logger;

    public BunyanLambdaILoggerTests()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaILoggerTests", "Trace"}
      };

      logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
    }

    [Fact]
    public void BunyanLambdaILogger_IsEnabled_Default()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:Default", "Critical"}
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.False(logger.IsEnabled(LogLevel.Trace));
    }

    [Fact]
    public void BunyanLambdaILogger_IsEnabled_No_Default()
    {
      var conf = new Dictionary<string, string>
      {
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");

      Assert.True(logger.IsEnabled(LogLevel.Critical));
      Assert.True(logger.IsEnabled(LogLevel.Trace));
    }

    [Fact]
    public void BunyanLambdaILogger_Critical_With_Message_And_Data()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:Default", "Information"}
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
      logger.LogCritical(message: "Message and Data", data: new {property1 = "value 1", property2 = "value 2"});
    }

    [Fact]
    public void BunyanLambdaILogger_Critical_Message()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:Default", "Information"}
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
      logger.LogCritical(message: "Only Message");
    }

    [Fact]
    public void BunyanLambdaILogger_Critical_Message_With_Args()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:Default", "Information"}
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
      logger.LogCritical("Message with {0} {1}", null, null, "argument", "argument2");
    }

    [Fact]
    public void BunyanLambdaILogger_Critical_Message_With_Data_and_Args()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:Default", "Information"}
      };

      // ReSharper disable once LocalVariableHidesMember
      var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
      logger.LogCritical("Message with {0} {1}", new {property1 = "value 1"}, new Exception("Exception!"), "argument", "argument2");
    }
  }
}
