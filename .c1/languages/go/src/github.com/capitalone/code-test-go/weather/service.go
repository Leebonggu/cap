package weather

import (
	"errors"
	"log"
	"os"
	"time"
)

var (
	Info  *log.Logger
	Error *log.Logger
)

const (
	NotImplemented = "Not Implemented"
)

func init() {
	Info = log.New(os.Stdout, "INFO: ", log.Ldate|log.Ltime|log.Lshortfile)
	Error = log.New(os.Stderr, "ERROR: ", log.Ldate|log.Ltime|log.Lshortfile)
}

// WeatherService is the backing service invoked by HTTP/REST handlers. Add
// whatever stateful fields you may need here.
type WeatherService struct {
}

// NewWeatherService creates an instance of the weather service struct
func NewWeatherService() *WeatherService {
	return &WeatherService{}
}

// GetMeasurement retrieves a single measurement based on timestamp
func (s *WeatherService) GetMeasurement(timestamp time.Time) (*Measurement, error) {
	return nil, errors.New(NotImplemented)
}

// CreateMeasurement creates and stores a new measurement
func (s *WeatherService) CreateMeasurement(newMeasurement Measurement) error {
	return errors.New(NotImplemented)
}

// GetStats obtains a list of statistics from the system based on stats, metrics, and a time range
func (s *WeatherService) GetStats(stats []string, metrics []string, from time.Time, to time.Time) ([]StatisticRow, error) {
	return nil, errors.New(NotImplemented)
}
