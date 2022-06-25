using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;

namespace BunyanLambdaLogger.Tests;

[ExcludeFromCodeCoverage]
public static class BunyanLambdaLoggerExtensions
{
  internal static JObject TestCreateDataSet(string message, object data, object[] args)
  {
    if (data is string)
    {
      args ??= new object[] { };
      args = new[] {data}.Concat(args).ToArray();
      data = null;
    }

    var dataSet = JObject.FromObject(data ?? new { });
    dataSet.Add("msg", string.Format(message, args));
    return dataSet;
  }

  internal static string TestMessageFormatter(object state, Exception error)
  {
    return state.ToString();
  }
}
