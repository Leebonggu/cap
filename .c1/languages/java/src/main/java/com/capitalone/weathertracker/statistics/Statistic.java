package com.capitalone.weathertracker.statistics;

import com.fasterxml.jackson.annotation.JsonProperty;

public enum Statistic {
  @JsonProperty("min") MIN,
  @JsonProperty("max") MAX,
  @JsonProperty("average") AVERAGE,
}
