/**
 * @property {Date} timestamp
 */
export class Measurement {
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
