using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalOne.WeatherTracker.Measurements
{
  public class MeasurementController : Controller
  {
    private readonly IMeasurementStore measurementStore;

    public MeasurementController(IMeasurementStore measurementStore)
    {
      this.measurementStore = measurementStore;
    }

    // features/01-measurements/01-add-measurement.feature
    [HttpPost, Route("/measurements")]
    public IActionResult CreateMeasurement([FromBody] Measurement measurement)
    {
      if (measurement == null || !ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      measurementStore.Insert(measurement);

      return Created($"/measurements/{DateConverter.ToString(measurement.Timestamp)}", measurement);
    }

    // features/01-measurements/02-get-measurement.feature
    [HttpGet, Route("/measurements/{date:datetime}")]
    public IActionResult GetMeasurement([FromRoute] DateTime date)
    {
      Measurement measurement = null;

      // web api converts dates passed as query params to local time zone
      measurement = this.measurementStore.Get(date.ToUniversalTime());

      if (measurement == null)
      {
        return NotFound();
      }

      return Ok(measurement);
    }
  }
}
