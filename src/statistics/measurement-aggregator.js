import { HttpError } from '../errors';
import { Measurement } from '../measurements/measurement';

/**
 * Compute statistics for given measurements
 * @param {Measurement} measurements
 * @param {String[]} metrics
 * @param {String[]} stats
 * @return {*}
 */

export function computeStats(measurements, metrics, stats) {
  const caculator = {
    "average": function (arr) {
      let sum = 0;
      let total = arr.length;
      if (total === 0) {
        return 0;
      }
      arr.forEach((number) => {
        sum += number;
      });
      const average = Number((sum / total).toFixed(1))
      return average;
    },
    "min": function(arr) {
      return Math.min(...arr);
    },
    "max": function(arr) {
      return Math.max(...arr);
    },
  };

  const result = [];
  const reArrangedWeatherData = {}
  metrics.forEach(metric => {
    if (metric === 'precipitation') {
      return [];
    }
    measurements.forEach(eachWeather => {
      if(!reArrangedWeatherData.hasOwnProperty(metric)) {
        reArrangedWeatherData[metric] = [];
      } 
      if(eachWeather.metrics.has(metric)) {
        reArrangedWeatherData[metric].push(eachWeather.metrics.get(metric));
      }
    });
  });
  Object.keys(reArrangedWeatherData).forEach(metric => {
    stats.forEach(stat => {
      const caculatedValue = caculator[stat](reArrangedWeatherData[metric]);
      result.push({"metric": metric, "stat": stat,  "value": caculatedValue});
    });
  });
  return result;
}
