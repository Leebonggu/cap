package com.capitalone.weathertracker.statistics;

import java.util.List;

import com.capitalone.weathertracker.measurements.Measurement;

public interface MeasurementAggregator {
  List<AggregateResult> analyze(List<Measurement> measurements, List<String> metrics, List<Statistic> stats);
}
