/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
extern alias contracts;
using System.Collections.Generic;
using Dolittle.Runtime.Applications;
using Dolittle.Services;
using grpc = contracts::Dolittle.TimeSeries.Runtime.DataPoints;

namespace Dolittle.TimeSeries.Runtime.DataPoints
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> - providing application services
    /// for working with datapoints
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly DataPointProcessorsService _dataPointProcessorsService;
        readonly DataPointStreamService _dataPointStreamService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPointProcessorsService"></param>
        /// <param name="dataPointStreamService"></param>
        public RuntimeServices(
            DataPointProcessorsService dataPointProcessorsService,
            DataPointStreamService dataPointStreamService)
        {
            _dataPointProcessorsService = dataPointProcessorsService;
            _dataPointStreamService = dataPointStreamService;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "TimeSeries";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_dataPointProcessorsService, grpc.DataPointProcessors.BindService(_dataPointProcessorsService), grpc.DataPointProcessors.Descriptor),
                new Service(_dataPointStreamService, grpc.DataPointStream.BindService(_dataPointStreamService), grpc.DataPointStream.Descriptor),
            };
        }
    }
}