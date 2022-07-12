## Payment Gateway
[![Build and Test](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/build-test.yml/badge.svg)](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/build-test.yml)
[![Docker Build](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/docker-build.yml/badge.svg)](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/docker-build.yml)
[![Publish Swagger](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/swagger-publish.yml/badge.svg)](https://github.com/KarimDarwish/checkout-payment-gateway/actions/workflows/swagger-publish.yml)

Swagger API Documentation:
[![Swagger API Documentation](https://validator.swagger.io/validator?url=https://karimdarwish.github.io/checkout-payment-gateway/swagger.json)](https://karimdarwish.github.io/checkout-payment-gateway/)

Content:

* [Setup](#Setup)
* [Architecture](#Architecture)
* [Functionality and Flow](#Overview)
* [Overview](#Overview)
* [Overview](#Overview)

# Setup

The application has been dockerized, only Docker is needed to start it locally.

### Docker Compose
To start the payment gateway using docker compose, execute 

``docker compose up`` or `docker-compose up` (depending on your Docker version)

in the root directory of the project.

# Architecture
<details>
  <summary>Click to expand</summary>
	test
</details>

# Functionality and Flow
<details>
  <summary>Click to expand</summary>
	test
</details>

# Assumptions
<details>
  <summary>Click to expand</summary>
	test
</details>

# Areas for Improvement
<details>
  <summary>Click to expand</summary>
	test
</details>

# Extra Mile Bonus Points

## CI

A continuous integration (CI) pipeline has been created using GitHub Action that performs an automated build and test on every pull request to the main branch.

Two additional jobs run on every main commit: 

- a ``docker-build`` job which attempts to build the docker image (this can be extended to a continuous deployment pipeline in the future)
- a ``swagger-publish`` job which uses the `swagger.json` file to build a Swagger UI and publishes it to GitHub Pages


## Metrics

A ``/metrics`` endpoint has been made available using `prometheus-net` where metrics can be scraped and processed by observability tools (e.g. Prometheus).

Available metrics are:

- HTTP metrics for every endpoint (request duration, status code, method etc.)
- ``payment_gateway_payments_processed_total``: a counter that increases for every processed payment
- ``payment_gateway_bank_requests_total``: a counter that increases for every request made to the bank
- ``payment_gateway_bank_requests_failed``: a counter that increases for every failed request to the bank (due to the bank rate limiting us)

In production, this endpoint would not be exposed to the public. Instead it should only be available to internal observability toos.

## Health Checks

Using ASP.NET Core Health Checks, a specific ``/health`` endpoint has been configured to allow for health probes of the application.

Currently it is used as health check within the ``Dockerfile`` to let Docker know whether the application is available or not.

In the future this can be improved to:

- include other dependencies (database, message queue, etc.)
- be used as Startup/Readiness/Liveness probe within Kubernetes
- include a ``/ready`` endpoint to differentiate between readiness and liveness

## Fault Tolerance

One assumption that has been made is that we need to take care of rate limits by the bank.
These occur randomly in the mocked bank.

To prevent this failure from reaching our merchants, retries using ``Polly`` have been implemented.

The service retries the payment request 5 times with a delay of 50ms between retry.

This can be extended to:

- use a different backoff strategy to avoid sending too many requests while still being rate limited
- take care of idempotency in requests so that only idempotent requests are retried to not cause any unwanted side effects


## Swagger 

To document the API of the service, Swagger is being used.

When starting the service in development mode, swagger is available under:

``localhost:5044/swagger``

This is disabled in production builds.

Instead, a ``swagger.json`` file is generated on build time that is used to create and upload a Swagger UI to a GitHub Pages site.

It is available under: https://karimdarwish.github.io/checkout-payment-gateway/

## Hardened Dockerfile

To improve security and harden the environment the application runs in, several measures have been taken:

- A separate (non-root) user is created that runs the application within the container
- An alpine based image of the .NET runtime is used (fewer known vulnerabilities)
- Port 8080 is used for the service to avoid security issues with a default port 80

# Cloud Technologies
<details>
  <summary>Click to expand</summary>
	test
</details>


