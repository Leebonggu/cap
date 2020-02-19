using System;
using System.Collections.Generic;

namespace CapitalOne.WeatherTracker.Measurements
{
  public interface IMeasurementStore
  {
    void Insert(Measurement measurement);
    Measurement Get(DateTime timestamp);
  }
}
