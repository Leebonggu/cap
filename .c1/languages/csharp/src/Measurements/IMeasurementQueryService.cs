using System;
using System.Collections.Generic;

namespace CapitalOne.WeatherTracker.Measurements
{
  public interface IMeasurementQueryService
  {
    IEnumerable<Measurement> QueryDateRange(DateTime fromDateTime, DateTime toDateTime);
  }
}
