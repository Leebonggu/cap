To install dependencies:

    dotnet restore

If you would like to add additional dependencies, simply run:

    dotnet add package <package-name>

To run the test suite:

    dotnet msbuild /target:TestIntegration

Test output is written to both `stdout` and `integration-test.log`

To run the app:

    dotnet run

If you wish to run the integration tests on your own machine, you will need to
install [NodeJS][] v8 or greater in addition to .NET Core 2

[NodeJS]: https://nodejs.org/
