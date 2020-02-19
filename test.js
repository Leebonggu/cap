/**
 * @property {Date} timestamp
 */
class Measurement {
  constructor() {
    /** @private */
    this.metrics = new Map();
  }

  /**
   * @param {String} name
   * @param {Number} value
   */
  setMetric(name, value) {
    this.metrics.set(name, value);
  }

  /**
   * @param {String} name
   * @return {Number}
   */
  getMetric(name) {
    return this.metrics.get(name);
  }
}

const measurement = new Measurement();
measurement.timestamp = new Date("2015-09-01T16:20:00.000Z");
// measurement.setMetric("timestamp", measurement.timestamp)
measurement.setMetric('temperature', +27.1);
measurement.setMetric('dewPoint', +16.7 );
measurement.setMetric('precipitation', +0);
// console.log(measurement.getMetric('temperature'))
console.log(new Date(measurement.timestamp) === new Date(measurement.timestamp))
// console.log(measurement.metrics.entries())

// console.log(measurement.metrics.entries());
// measurement.metrics.forEach((value, key) => {
//   console.log(typeof value, key);
// });

// const a = new Response({a: 1}, {"status": 201});

// console.log(a)

// console.log(measurement.metrics.keys());

console.log(measurement.metrics.get('temperature'));
const a = measurement.metrics.keys();
console.log(a);
for (let i of a ) {
  console.log(11, measurement.metrics.get(i));
}