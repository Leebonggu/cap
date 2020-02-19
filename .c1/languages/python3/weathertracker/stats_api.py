from flask import request, jsonify
from flask.views import MethodView
from werkzeug.exceptions import abort
from weathertracker.stats import get_stats
from weathertracker.utils.conversion import (
    convert_to_datetime,
    DatetimeConversionException,
)


class StatsAPI(MethodView):
    # features/02-stats/01-get-stats.feature
    def get(self):
        stats = request.args.getlist("stat")
        metrics = request.args.getlist("metric")
        from_datetime = request.args.get("fromDateTime")
        to_datetime = request.args.get("toDateTime")

        # Validate query params are provided
        if any(
            [
                len(stats) == 0,
                len(metrics) == 0,
                from_datetime is None,
                to_datetime is None,
            ]
        ):
            return abort(400)
        try:
            from_datetime = convert_to_datetime(from_datetime)
            to_datetime = convert_to_datetime(to_datetime)
        except DatetimeConversionException:
            return abort(400)

        stats = get_stats(stats, metrics, from_datetime, to_datetime)
        return stats
