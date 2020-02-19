/***************************
 * DO NOT CHANGE THIS FILE *
 ***************************/

using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CapitalOne.WeatherTracker
{
  public class Program
  {
    private static readonly ushort DefaultPort = 8000; // HackerRank uses this port

    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseUrls(string.Format("http://0.0.0.0:{0}/", GetPort()))
        .Build();

    private static ushort GetPort()
    {
      var portStr = Environment.GetEnvironmentVariable("PORT");
      ushort port;

      return ushort.TryParse(portStr, out port) ? port : DefaultPort;
    }
  }
}
