using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

using Newtonsoft.Json;
using CapitalOne.WeatherTracker.Measurements;

namespace CapitalOne.WeatherTracker
{
  public class MeasurementConverter : JsonConverter
  {
    private const string TIMESTAMP_PROPERTY_NAME = "timestamp";

    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(Measurement);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      DateTime timestamp = DateTime.MinValue;
      bool hasTimestamp = false;
      Dictionary<string, double> metrics = new Dictionary<string, double>();

      while (reader.Read())
      {
        if (reader.TokenType == JsonToken.PropertyName)
        {
          continue;
        }
        if (reader.Path.Trim().ToLower() == TIMESTAMP_PROPERTY_NAME)
        {
          hasTimestamp = DateTime.TryParse(reader.Value.ToString(), out timestamp);
        }
        else if (reader.TokenType == JsonToken.Float)
        {
          metrics.Add(reader.Path, (double)reader.Value);
        }
        else if (reader.TokenType == JsonToken.Integer)
        {
          metrics.Add(reader.Path, Convert.ToDouble(reader.Value));
        }
        else if (reader.TokenType == JsonToken.EndObject || reader.TokenType == JsonToken.StartObject)
        {
          // noop
        }
        else
        {
          throw new Exception("Values must be a number");
        }
      }

      if (!hasTimestamp)
      {
        throw new Exception("Timestamp required");
      }

      return new Measurement(timestamp, metrics);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var measurement = value as Measurement;

      if (measurement == null)
      {
        return;
      }

      writer.WriteStartObject();
      writer.WritePropertyName(TIMESTAMP_PROPERTY_NAME);
      writer.WriteValue(DateConverter.ToString(measurement.Timestamp));

      foreach (var field in measurement.Metrics)
      {
        writer.WritePropertyName(field.Key);
        writer.WriteValue(field.Value);
      }

      writer.WriteEndObject();
      writer.Flush();
    }
  }
}
