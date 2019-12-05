using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace BunyanLambdaLogger.Tests
{
  public static class BunyanLambdaLoggerExtensions
  {
    internal static JObject TestCreateDataSet(string message, object data, object[] args)
    {
      if (data != null && data is string)
      {
        args = args ?? new object[] { };
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
}
