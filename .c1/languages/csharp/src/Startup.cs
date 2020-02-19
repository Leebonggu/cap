using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CapitalOne.WeatherTracker.Measurements;
using CapitalOne.WeatherTracker.Statistics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CapitalOne.WeatherTracker
{
  // See https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddMvc(options =>
        {
          options.Filters.Add(new NotImplementedExceptionFilter());
        })
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.Converters.Add(new MeasurementConverter());
        });

      services.AddSingleton<IMeasurementStore, NotImplementedService>();
      services.AddSingleton<IMeasurementQueryService, NotImplementedService>();
      services.AddSingleton<IMeasurementAggregator, NotImplementedService>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDeveloperExceptionPage();

      app.UseMvc();
    }

    private class NotImplementedExceptionFilter : IExceptionFilter
    {
      public void OnException(ExceptionContext context)
      {
        if (!(context.Exception is NotImplementedException)) return;

        context.Result = new StatusCodeResult(501);
        context.ExceptionHandled = true;
      }
    }
  }
}
