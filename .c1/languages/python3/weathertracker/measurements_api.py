from flask import request, jsonify
from flask.views import MethodView
from werkzeug.exceptions import abort
from weathertracker.utils.conversion import (
    convert_to_datetime,
    DatetimeConversionException,
)


class MeasurementsAPI(MethodView):

    # features/01-measurements/01-add-measurement.feature
    def post(self):
        # TODO:
        abort(501)

    # features/01-measurements/02-get-measurement.feature
    def get(self, timestamp):

        try:
            timestamp = convert_to_datetime(timestamp)
        except DatetimeConversionException:
            return abort(400)

        # TODO:
        abort(501)
