import express from "express";
import * as store from "./measurement-store";
import { Measurement } from "./measurement";
import { HttpError } from "../errors";

// getMetric: what this?

const router = express.Router();

export function register(app) {
  app.use("/measurements", router);
}

router.post("/", (req, res) => {
  const measurement = parseMeasurement(req.body);

  store.add(measurement);

  res.location(`/measurements/${measurement.timestamp.toISOString()}`).sendStatus(201);
});

router.get("/:timestamp", (req, res) => {
  const result = store.fetch(new Date(req.params.timestamp));
  if (result) {
    res.statusCode = 200;
    return res.json(serializeMeasurement(result)).sendStatus(200);
  } else {
    res.sendStatus(404);
  }
});

function parseMeasurement({ timestamp, ...metrics }) {
  const measurement = new Measurement();
  measurement.timestamp = new Date(timestamp);

  if (isNaN(measurement.timestamp)) throw new HttpError(400);

  for (const metric in metrics) {
    
    if (!metrics.hasOwnProperty(metric)) continue;

    const value = metrics[metric];
    if (isNaN(value)) throw new HttpError(400);

    measurement.setMetric(metric, +value);
  }

  return measurement;
  
  // Measurement {
  //   metrics:
  //    Map {
  //      'temperature' => 27.1,
  //      'dewPoint' => 16.7,
  //      'precipitation' => 0 },
  //   timestamp: 2015-09-01T16:20:00.000Z }
}

function serializeMeasurement(measurement) {
  const out = { timestamp: measurement.timestamp.toISOString() };

  for (const [metric, value] of measurement.metrics.entries()) {
    out[metric] = value;
  }

  return out;
}
