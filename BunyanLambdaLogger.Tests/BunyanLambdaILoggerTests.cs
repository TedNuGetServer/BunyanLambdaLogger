using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using Xunit;
using static BunyanLambdaLogger.Tests.BunyanLambdaLoggerExtensions;

namespace BunyanLambdaLogger.Tests;

[ExcludeFromCodeCoverage]
public class BunyanLambdaILoggerTests
{
  [Fact]
  public void BunyanLambdaILogger_IsEnabled_Default()
  {
    var conf = new Dictionary<string, string>
    {
      {"Lambda.Logging:LogLevel:Default", "Critical"}
    };

    var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");

    Assert.True(logger.IsEnabled(LogLevel.Critical));
    Assert.False(logger.IsEnabled(LogLevel.Trace));
  }

  [Fact]
  public void BunyanLambdaILogger_IsEnabled_No_Default()
  {
    var conf = new Dictionary<string, string>();

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

    var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");
    logger.LogCritical("Message with {0} {1}", new {property1 = "value 1"}, new Exception("Exception!"), "argument", "argument2");
  }

  [Fact]
  public void BunyanLambdaILogger_With_EventId()
  {
    var conf = new Dictionary<string, string>
    {
      {"Lambda.Logging:LogLevel:Default", "Information"}
    };

    var eventId = new EventId(1, "NewEvent");

    var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");

    var dataSet = TestCreateDataSet("unit-tests", "EF Core event", null);

    logger.Log(logLevel: LogLevel.Information, eventId: eventId, state: dataSet, exception: null,
      formatter: TestMessageFormatter);
  }

  [Fact]
  public void BunyanLambdaILogger_Without_EventId()
  {
    var conf = new Dictionary<string, string>
    {
      {"Lambda.Logging:LogLevel:Default", "Information"}
    };

    var eventId = new EventId();

    var logger = Logger.Create(conf, nameof(BunyanLambdaILoggerTests), "unit-tests");

    var dataSet = TestCreateDataSet("unit-tests", "EF Core event", null);

    logger.Log(logLevel: LogLevel.Information, eventId: eventId, state: dataSet, exception: null,
      formatter: TestMessageFormatter);
  }

  [Fact]
  public void GetLambdaLoggerOptions_Should_Throw_When_Config_Is_Null_Test()
  {
    Assert.Throws<ArgumentNullException>(() => IConfigurationExtensions.GetLambdaLoggerOptions(null));
  }
}
