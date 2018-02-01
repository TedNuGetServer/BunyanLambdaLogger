using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace BunyanLambdaLogger.Tests
{
  public class BunyanLamdaLoggerWithEnvTest
  {
    [Fact]
    public void ShouldReturnJsonWithAnEnvProperyOfDevelopmentTest()
    {
      var conf = new Dictionary<string, string>
      {
        {"Lambda.Logging:LogLevel:BunyanLambdaLogger*", "Trace"}
      };

      var logger = Logger2.Create(conf, nameof(BunyanLamdaLoggerWithEnvTest), "development");

      logger.LogTrace("This should include a property of env with a value of development");
    }
  }

  public static class Logger2
  {
    private static ILogger Create(Dictionary<string, string> configuration, string categoryName, string applicationName, string environment)
    {
      var builder = new ConfigurationBuilder().AddInMemoryCollection(configuration);
      var Configuration = builder.Build();
      var serviceProvider = new ServiceCollection()
        .AddLogging()
        .AddSingleton<IConfiguration>(Configuration)
        .BuildServiceProvider();

      var loggerOptions = Configuration.GetLambdaLoggerOptions();
      var factory = serviceProvider.GetService<ILoggerFactory>();

      var logger = factory.AddBunyanLambdaLogger(loggerOptions, applicationName, environment).CreateLogger(categoryName);
      return logger;
    }

    public static ILogger Create(Dictionary<string, string> configuration, string categoryName, string environment)
    {
      return Create(configuration, categoryName, "Test-Application", "development");
    }
  }
}
