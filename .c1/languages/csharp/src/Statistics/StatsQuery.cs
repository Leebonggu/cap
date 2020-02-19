using System;

namespace CapitalOne.WeatherTracker.Statistics
{
  public class StatsQuery
  {
    public string[] Stat { get; set; }
    public string[] Metric { get; set; }
    public DateTime FromDateTime { get; set; }
    public DateTime ToDateTime { get; set; }
  }
}
