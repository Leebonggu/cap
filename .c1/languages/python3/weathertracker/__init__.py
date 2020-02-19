from weathertracker.measurements_api import MeasurementsAPI
from weathertracker.stats_api import StatsAPI
from flask import Flask


def create_app():
    app = Flask(__name__)

    measurements_api = MeasurementsAPI.as_view("measurements")
    app.add_url_rule("/measurements", view_func=measurements_api, methods=["POST"])
    app.add_url_rule(
        "/measurements/<timestamp>", view_func=measurements_api, methods=["GET"]
    )

    stats_api = StatsAPI.as_view("stats")
    app.add_url_rule("/stats", view_func=stats_api, methods=["GET"])
    return app


app = create_app()


@app.route("/")
def root():
    return "Weather tracker is up and running!"
