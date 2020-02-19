import express from 'express';
import { queryDateRange } from '../measurements/measurement-store';
import { computeStats } from './measurement-aggregator';
import { HttpError } from '../errors';

const router = express.Router();

export function register(app) {
  app.use('/stats', router);
}

router.get('/', (req, res) => {
  const metrics = asArray(req.query.metric); //array
  const stats = asArray(req.query.stat); //array

  const fromDateTime = new Date(req.query.fromDateTime);
  const toDateTime = new Date(req.query.toDateTime);

  if (!metrics || !stats || !fromDateTime || !toDateTime) {
    throw new HttpError(500);
  }

  const measurements = queryDateRange(fromDateTime, toDateTime);
  const result = computeStats(measurements, metrics, stats);
  if (result) {
    res.status(200);
    res.json(result);
  } else {
    res.sendStatus(404);
  }
});

function asArray(val) {
  if (val == null) return null;

  return Array.isArray(val) ? val : [val];
}
