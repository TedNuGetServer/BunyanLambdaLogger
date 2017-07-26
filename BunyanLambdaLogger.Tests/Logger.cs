using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BunyanLambdaLogger.Tests
{
  public static class Logger
  {
    public static ILogger Create(Dictionary<string, string> configuration, string categortName, string applicationName)
    {
      var builder = new ConfigurationBuilder().AddInMemoryCollection(configuration);
      var Configuration = builder.Build();
      var serviceProvider = new ServiceCollection()
        .AddLogging()
        .AddSingleton<IConfiguration>(Configuration)
        .BuildServiceProvider();

      var loggerOptions = Configuration.GetLambdaLoggerOptions();
      var factory = serviceProvider.GetService<ILoggerFactory>();

      var logger = factory.AddBunyanLambdaLogger(loggerOptions, applicationName).CreateLogger(categortName);
      return logger;
    }

    public static ILogger Create(Dictionary<string, string> configuration, string categortName)
    {
      return Create(configuration, categortName, null);
    }
  }
}
