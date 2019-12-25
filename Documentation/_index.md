---
title: Runtime
description: The home of the TimeSeries Runtime
keywords: TimeSeries, Runtime
author: einari
weight: 1
---

The TimeSeries Runtime extends the [Dolittle runtime](/runtime/runtime) with specific
capabilities for measurements and data points in a time series. Its bundled as
as part of the official [Dolittle Runtime Docker image](https://hub.docker.com/r/dolittle/runtime).

TimeSeries add the capability of collecting data points in a standardized way,
identify these to provide an unambiguous identity and then expose them as metrics
through the Dolittle Runtime. These metrics can then be measured at any given time and
at your desired interval.

The metrics are exposed using the [Prometheus data model](https://prometheus.io/docs/concepts/data_model/)
and is accessible through the Runtime.