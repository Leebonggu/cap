To compile and test:

    mvn clean verify

Test output is written to both `stdout` and `integration-test.log`

If you would like to add additional dependencies, add their information to
`pom.xml`.

To run the app:

    mvn spring-boot:run -e

If you wish to run the integration tests on your own machine, you will need to
install [NodeJS][] v8 or greater in addition to JDK 8 and Maven 2

[NodeJS]: https://nodejs.org/
