package com.capitalone.weathertracker.statistics;

import com.capitalone.weathertracker.statistics.Statistic;
import com.fasterxml.jackson.annotation.JsonGetter;

public class AggregateResult {
  private String metric;
  private Statistic statistic;
  private double value;

  public AggregateResult(String metric, Statistic statistic, double value) {
    this.metric = metric;
    this.statistic = statistic;
    this.value = value;
  }

  @JsonGetter("metric")
  public String getMetric() {
    return this.metric;
  }

  @JsonGetter("stat")
  public Statistic getStatistic() {
    return this.statistic;
  }

  @JsonGetter("value")
  public double getValue() {
    return this.value;
  }
}
