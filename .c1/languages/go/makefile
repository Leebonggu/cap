port = 8000
tester_version = 1.1.1
npm := npm --prefix .
npm_bin = $(shell $(npm) bin)
integration_test = $(npm_bin)/take-home-integration-test
out_file = bin/weathertracker
log_file = integration-test.log
main_file = src/github.com/capitalone/code-test-go/main.go

export GOPATH := $(shell pwd)

$(out_file):
	go build -o $(out_file) $(main_file)

$(integration_test):
	$(npm) install --no-save ./assets/c1-code-test-take-home-tester-$(tester_version).tgz

clean:
	rm -f $(out_file)

run:
	go run $(main_file)

test: $(integration_test) clean $(out_file)
	node --no-warnings \
	$(integration_test) \
	features \
	--check-new \
	--no-color \
	--command "$(out_file)" \
	--port $(port) \
	 --out-file $(log_file) \
	-- \
	--tags 'not @skip'

.PHONY: test
