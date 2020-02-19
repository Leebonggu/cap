package main

import (
	"fmt"
	"net/http"
	"os"

	"github.com/capitalone/code-test-go/weather"
	"github.com/gorilla/mux"
)

func main() {
	weatherService := weather.NewWeatherService()
	measurementsHandler := weather.NewMeasurementsHandler(weatherService)
	statsHandler := weather.NewStatisticsHandler(weatherService)

	r := mux.NewRouter()
	r.HandleFunc("/", homeHandler).Methods("GET")
	r.HandleFunc("/measurements", measurementsHandler.CreateMeasurement).Methods("POST")
	r.HandleFunc("/measurements/{timestamp}", measurementsHandler.GetMeasurement).Methods("GET")
	r.HandleFunc("/stats", statsHandler.GetStats).Methods("GET")

	port := os.Getenv("PORT")
	if len(port) == 0 {
		port = "8000"
	}

	fmt.Printf("Weather Tracker service listening on port %s\n", port)
	http.ListenAndServe(fmt.Sprintf(":%s", port), r)
}

func homeHandler(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Weather Tracker is up!\n")
}
