package weather

import (
	"encoding/json"
	"net/http"
	"time"
)

type statisticsService interface {
	GetStats(stats []string, metrics []string, from time.Time, to time.Time) ([]StatisticRow, error)
}

// StatisticsHandler is a RESTful HTTP endpoint for the /stats URL
type StatisticsHandler struct {
	svc statisticsService
}

// NewStatisticsHandler creates a new statistics handler
func NewStatisticsHandler(svc statisticsService) *StatisticsHandler {
	return &StatisticsHandler{
		svc,
	}
}

// GetStats is the HTTP GET handler for the /stats resource
func (h *StatisticsHandler) GetStats(w http.ResponseWriter, r *http.Request) {
	Info.Println("Handler invoked")
	vals := r.URL.Query()
	stats := vals["stat"]
	metrics := vals["metric"]
	fromRaw := vals.Get("fromDateTime")
	toRaw := vals.Get("toDateTime")

	fromStamp, err := time.Parse(time.RFC3339, fromRaw)
	if err != nil {
		Error.Println(err)
		http.Error(w, http.StatusText(http.StatusBadRequest), http.StatusBadRequest)
		return
	}

	toStamp, err := time.Parse(time.RFC3339, toRaw)
	if err != nil {
		Error.Println(err)
		http.Error(w, http.StatusText(http.StatusBadRequest), http.StatusBadRequest)
		return
	}

	statList, err := h.svc.GetStats(stats, metrics, fromStamp, toStamp)
	if err != nil {
		Error.Println(err)
		if err.Error() == NotImplemented {
			http.Error(w, http.StatusText(http.StatusNotImplemented), http.StatusNotImplemented)
		} else {
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}
		return
	}

	bytes, err := json.Marshal(statList)
	if err != nil {
		Error.Println(err)
		http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		return
	}

	w.Write(bytes)
	w.WriteHeader(http.StatusOK)
}
