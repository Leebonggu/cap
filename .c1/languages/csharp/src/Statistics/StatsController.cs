using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalOne.WeatherTracker.Statistics
{
  public class StatsController : Controller
  {
    private readonly IMeasurementAggregator measurementAggregator;

    public StatsController(IMeasurementAggregator measurementAggregator)
    {
      this.measurementAggregator = measurementAggregator;
    }

    // features/02-stats/01-get-stats.feature
    [HttpGet, Route("/stats")]
    public IActionResult GetStats(StatsQuery query)
    {
      // web api converts dates passed as query params to local time zone
      query.FromDateTime = query.FromDateTime.ToUniversalTime();
      query.ToDateTime = query.ToDateTime.ToUniversalTime();

      return Ok(measurementAggregator.GetStatsByDateRange(query));
    }
  }
}
