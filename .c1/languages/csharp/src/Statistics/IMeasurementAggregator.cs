using System;
using System.Collections.Generic;

namespace CapitalOne.WeatherTracker.Statistics
{
  public interface IMeasurementAggregator
  {
    IEnumerable<Statistic> GetStatsByDateRange(StatsQuery query);
  }
}
