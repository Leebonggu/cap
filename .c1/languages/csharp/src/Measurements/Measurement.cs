using System;
using System.Collections.Generic;

namespace CapitalOne.WeatherTracker.Measurements
{
  public class Measurement
  {
    public Measurement(DateTime timestamp, Dictionary<string, double> metrics)
    {
      this.Timestamp = timestamp;
      this.Metrics = metrics;
    }

    public DateTime Timestamp { get; }

    public IReadOnlyDictionary<string, double> Metrics { get; }
  }
}
