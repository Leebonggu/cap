import { Measurement } from './measurement';
import { HttpError } from '../errors';


const store = [];

/**
 * Add new measurement
 * @param {Measurement} measurement to be added
 * @new
 */
export function add(measurement) {
  store.push(measurement);
  // const result = {};
  // if (!measurement.timestamp) {
  //   throw new HttpError(400);
  // } else {
  //   result['timestamp'] = measurement.timestamp;
  //   measurement.metrics.forEach((value, key) => {
  //     if (typeof value !== 'number' || value === undefined) {
  //       throw new HttpError(400)
  //     }
  //     result[key] = Number(value);
  //   });
  //   store.concat([result]);
  // }

  // Measurement {
  //   metrics:
  //    Map {
  //      'temperature' => 27.1,
  //      'dewPoint' => 16.7,
  //      'precipitation' => 0 },
  //   timestamp: 2015-09-01T16:20:00.000Z }
  // throw new HttpError(501);
  // throw new HttpError(400);
}

/**
 * Get existing measurement
 * @param {Date} timestamp when measurement was taken
 * @returns {Measurement} measurement for the particular date
 */

export function fetch(timestamp) {
  // | "2015-09-01T16:00:00.000Z" | 27.1        | 16.7     | 0             |
  // | "2015-09-01T16:10:00.000Z" | 27.3        | 16.9     | 0             |
  // | "2015-09-01T16:20:00.000Z" | 27.5        | 17.1     | 0             |
  // | "2015-09-01T16:30:00.000Z" | 27.4        | 17.3     | 0             |
  // | "2015-09-01T16:40:00.000Z" | 27.2        | 17.2     | 0             |
  // | "2015-09-02T16:00:00.000Z" | 28.1        | 18.3     | 0             |
  // getMetric

  const filterData = store.filter((each) => {
    return new Date(each.timestamp).getTime() === new Date(timestamp).getTime();
  });
  const data = filterData[0];
  if (data) {
    return data;
  }
  return null;
  // return data;

  // new Date(req.params.timestamp)
  // const measurement = new Measurement();
  // measurement.metrics.forEach((value, key, map) => {
  //   if (key === 'timestamp' && new Date(value).toISOString() !== timestamp) {
  //     return new HttpError(400);
  //   } else {
  //     return measurement.getMetric(key);
  //   }
  // });

  // const filtedData = store.filter((each) => {
  //   return new Date(each.timestamp) === timestamp;
  // });
  // const data = filtedData[0];
  // if (data) {
  //   const measurement = new Measurement();
  //   measurement.timestamp = new Date(data.timestamp);
  //   measurement.setMetric('temperature', +data['temperature']);
  //   measurement.setMetric('dewPoint', +data['dewPoint']);
  //   measurement.setMetric('precipitation', +data['precipitation']);
  //   return measurement;
  // }
  // return data;
  // const filtedData = store.filter((each) => {
  //   return new Date(each.timestamp) === timestamp;
  // });
  // const data = filtedData[0];

  // const result = measurement.getMetric(timestamp)
}

/**
 * Get the measurements within the given date range
 * @param {Date} start Lower bound for the query, inclusive
 * @param {Date} end Upper bound for the query, exclusive
 * 
 */

export function queryDateRange(from, to) {
  const result = store.filter(eachData => {
    if (new Date(from) <= new Date(eachData.timestamp) && new Date(eachData.timestamp) < new Date(to)) {
      return eachData;
    }
  });
  return result;
}
