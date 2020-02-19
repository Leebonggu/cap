port = 8000
tester_version = 1.1.1
npm := npm --prefix .
python = $(shell pipenv --py) # evaluate this once to improve performance in test
npm_bin = $(shell $(npm) bin)
integration_test = $(npm_bin)/take-home-integration-test
log_file = integration-test.log

pipenv_version = $(word 3,$(shell pipenv --version))

.PHONY: start
start:
	pipenv run python run.py

$(integration_test):
	$(npm) install --no-save ./assets/c1-code-test-take-home-tester-$(tester_version).tgz

.PHONY: check-pipenv-version

ifeq ("$(pipenv_version)","2018.7.1")
check-pipenv-version:
	@echo "Detected incompatible versions of pip and pipenv. Upgradeing pipenv."
	pip install --user --upgrade pipenv
endif

.PHONY: install
install: check-pipenv-version
	pipenv --bare install --dev

.PHONY: test
test: $(integration_test)
	node --no-warnings \
	$(integration_test) \
	features \
	--no-color \
	--check-new \
	--command "$(python) run.py" \
	--port $(port) \
	--out-file $(log_file) \
	-- \
	--tags 'not @skip'
