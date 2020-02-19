To install dependencies:

    make install

If you would like to add additional dependencies, simply run

    pipenv install <package-name>

To run the test suite:

    make test

Test output is written to both `stdout` and `integration-test.log`

To run the app:

    make start 

(All of these are also available in the "Run" menu)

If you wish to run the integration tests on your own machine, you will need to
install [NodeJS][] v8 or greater in addition to Python, make, and pipenv

[NodeJS]: https://nodejs.org/
