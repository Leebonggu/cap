package weather

import (
	"encoding/json"
  "time"
  "errors"
)

const (
	// StatMin is the string used to indicate a minimum operation
	StatMin = "min"
	// StatMax is the string used to indicate a max operation
	StatMax = "max"
	// StatAverage is the string used to indicate an average operation
  StatAverage = "average"

  // timeFormat is a Go timestamp constant, test harness requires 3 fractional second digits
  timeFormat = "2006-01-02T15:04:05.000Z"
)

// Measurement represents a measurement at a given time of a collection of metrics.
type Measurement struct {
	Timestamp time.Time          `json:"timestamp"`
	Metrics   map[string]float32 `json:"-"`
}

// StatisticRow represents a triple of metric, statistical function, and value
type StatisticRow struct {
	Metric string  `json:"metric"`
	Stat   string  `json:"stat"`
	Value  float32 `json:"value"`
}

// MarshalJSON is a custom marshaler used so that the Metrics field
// is flattened and those values are pushed up to the root JSON object.
func (m Measurement) MarshalJSON() ([]byte, error) {

  type MeasurementN Measurement
	b, _ := json.Marshal(MeasurementN(m))

	var rm map[string]json.RawMessage
	json.Unmarshal(b, &rm)

  rm["timestamp"] = json.RawMessage(m.Timestamp.Format(timeFormat))

	for k, v := range m.Metrics {
    if k != "timestamp" {
      b, _ = json.Marshal(v)
      rm[k] = json.RawMessage(b)
    }
	}

	return json.Marshal(rm)
}

// UnmarshalJSON is a custom unmarshaler used so that fields not on part of the core
// structure will be de-serialized into the Metrics field
func (m *Measurement) UnmarshalJSON(data []byte) error {

	var rm map[string]json.RawMessage
	json.Unmarshal(data, &rm)

	type MeasurementN Measurement
	var m2 MeasurementN
	json.Unmarshal(data, &m2)

	extras := make(map[string]float32)

	for k, v := range rm {
    if k == "timestamp" {
      continue
    }
		var floatVal float32
    err := json.Unmarshal(v, &floatVal)
    if err != nil {
      return err
    }
		extras[k] = floatVal
  }

  if m2.Timestamp.IsZero() {
    return errors.New("Missing or invalid timestamp")
  }

	m.Timestamp = m2.Timestamp
	m.Metrics = extras

	return nil
}
