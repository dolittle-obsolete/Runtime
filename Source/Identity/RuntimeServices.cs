/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Heads;
using Dolittle.Services;
using grpc = Dolittle.TimeSeries.Identity.Runtime;

namespace Dolittle.TimeSeries.Runtime.Identity
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> - providing runtime services
    /// for working with <see cref="TimeSeriesId"/> identities
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly TimeSeriesMapIdentifierService _timeSeriesMapIdentifierService;

        /// <summary>
        /// Initializes a new instance of <see cref="RuntimeServices"/>
        /// </summary>
        /// <param name="timeSeriesMapIdentifierService"><see cref="TimeSeriesMapIdentifierService"/> service</param>
        public RuntimeServices(TimeSeriesMapIdentifierService timeSeriesMapIdentifierService)
        {
            _timeSeriesMapIdentifierService = timeSeriesMapIdentifierService;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "TimeSeries";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_timeSeriesMapIdentifierService, grpc.TimeSeriesMapIdentifier.BindService(_timeSeriesMapIdentifierService), grpc.TimeSeriesMapIdentifier.Descriptor)
            };
        }
    }
}