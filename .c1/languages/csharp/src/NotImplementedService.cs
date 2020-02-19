
using System;
using System.Collections.Generic;
using CapitalOne.WeatherTracker.Measurements;
using CapitalOne.WeatherTracker.Statistics;

namespace CapitalOne.WeatherTracker
{
  // TODO: Delete this service and implement the service interfaces.
  internal class NotImplementedService : IMeasurementStore, IMeasurementQueryService, IMeasurementAggregator
  {
    public void Insert(Measurement measurement)
    {
      throw new NotImplementedException();
    }

    public Measurement Get(DateTime timestamp)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Measurement> QueryDateRange(DateTime fromDateTime, DateTime toDateTime)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Statistic> GetStatsByDateRange(StatsQuery query)
    {
      throw new NotImplementedException();
    }
  }
}
