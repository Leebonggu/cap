To run the app:

    make run

To run the tests:

    make test

Test output is written to both `stdout` and `integration-test.log`

If you need to add dependencies, please either manually copy them into the
vendor directory or use a tool that will populate the `vendor` directory for
you. Do NOT use Go 1.11 modules or any Go dependency manager that relies on
something _other_ than the vendor directory.

Business logic for the service is contained in the `weather/service.go` file.

If you wish to run the integration tests on your own machine, you will need to
install [NodeJS][] v8 or greater in addition to Go v1.10

[NodeJS]: https://nodejs.org/
