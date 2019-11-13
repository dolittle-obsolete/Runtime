---
title: Runtime
description: The home of the TimeSeries Runtime
keywords: TimeSeries, Runtime
author: einari
weight: 1
---

The TimeSeries Runtime is an extension to the Dolittle runtime and is packaged
as part of the Docker image found [here](https://hub.docker.com/r/dolittle/runtime).
TimeSeries gives a way to collect data points in a standardized way, identify these
with the correct TimeSeries identifier and then expose them as metrics through the
Dolittle Runtime. These metrics can then be measured at any given time and desired
interval.