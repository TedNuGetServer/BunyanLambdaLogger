using System;
using System.Linq;
using Microsoft.Extensions.Logging.Internal;
using Newtonsoft.Json.Linq;

namespace BunyanLambdaLogger.Tests
{
  public static class BunyanLambdaLoggerExtensions
  {
    internal static JObject TestCreateDataSet(string message, object data, object[] args)
    {
      if (data != null && data.GetType().Name.ToLower() == "string")
      {
        args = args ?? new object[] { };
        args = new[] {data}.Concat(args).ToArray();
        data = null;
      }

      var dataSet = JObject.FromObject(data ?? new { });
      dataSet.Add("msg", new FormattedLogValues(message, args).ToString());
      return dataSet;
    }

    internal static string TestMessageFormatter(object state, Exception error)
    {
      return state.ToString();
    }
  }
}
