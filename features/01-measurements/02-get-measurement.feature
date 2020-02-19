Feature: Get a measurement
  In order to learn what weather conditions were like at a specific time
  I want to be able to retrieve a measurement of several metrics at that time

  Background:
   # POST /measurements
   Given I have submitted new measurements as follows:
      | timestamp                  | temperature | dewPoint | precipitation |
      | "2015-09-01T16:00:00.000Z" | 27.1        | 16.7     | 0             |
      | "2015-09-01T16:10:00.000Z" | 27.3        | 16.9     | 0             |
      | "2015-09-01T16:20:00.000Z" | 27.5        | 17.1     | 0             |
      | "2015-09-01T16:30:00.000Z" | 27.4        | 17.3     | 0             |
      | "2015-09-01T16:40:00.000Z" | 27.2        | 17.2     | 0             |
      | "2015-09-02T16:00:00.000Z" | 28.1        | 18.3     | 0             |

  Scenario: Get a specific measurement
    # GET /measurements/2015-09-01T16:20:00.000Z
    When I get a measurement for "2015-09-01T16:20:00.000Z"
    Then the response has a status code of 200
    And the response body is:
      | timestamp                  | temperature | dewPoint | precipitation |
      | "2015-09-01T16:20:00.000Z" | 27.5        | 17.1     | 0             |

  Scenario: Get a measurement that does not exist
    # GET /measurements/2015-09-01T16:50:00.000Z
    When I get a measurement for "2015-09-01T16:50:00.000Z"
    Then the response has a status code of 404
