package com.capitalone.weathertracker.measurements;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;

import java.time.ZonedDateTime;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

import javax.validation.constraints.NotNull;

public class Measurement {
  @JsonProperty(value="timestamp") @NotNull
  private ZonedDateTime timestamp;

  @JsonAnySetter
  private Map<String, Double> metrics = new HashMap<>();
  private Map<String, Double> metricsView;

  public ZonedDateTime getTimestamp() {
    return timestamp;
  }

  @JsonAnyGetter
  public Map<String, Double> getMetrics() {
    if (metricsView == null)
      metricsView = Collections.unmodifiableMap(metrics);

    return metricsView;
  }

  public Double getMetric(final String metricName) {
    return metrics.get(metricName);
  }

  public static class Builder {
    private ZonedDateTime timestamp;
    private Map<String, Double> metrics = new HashMap<>();

    public Builder withTimestamp(final ZonedDateTime timestamp) {
      this.timestamp = timestamp;
      return this;
    }

    public Builder withMetric(final String name, final Double value) {
      metrics.put(name, value);
      return this;
    }

    public Measurement build() {
      if (timestamp == null) {
        throw new IllegalArgumentException("Timestamp is required");
      }

      Measurement result = new Measurement();
      result.timestamp = timestamp;
      result.metrics = metrics;

      return result;
    }
  }
}
