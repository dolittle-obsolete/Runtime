/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Dolittle.Runtime.Applications;
using Dolittle.Services;
using grpc = Dolittle.TimeSeries.Connectors.Runtime;

namespace Dolittle.TimeSeries.Runtime.Connectors
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanBindRuntimeServices"/> - providing application services
    /// for working with connectors
    /// </summary>
    public class RuntimeServices : ICanBindRuntimeServices
    {
        readonly PullConnectorsService _pullConnectorsService;
        readonly StreamConnectorsService _streamConnectorsService;

        /// <summary>
        /// Initializes a new instance of <see cref="RuntimeServices"/>
        /// </summary>
        /// <param name="pullConnectorsService">Instance of <see cref="PullConnectorsService"/></param>
        /// <param name="streamConnectorsService">Instance of <see cref="StreamConnectorsService"/></param>
        public RuntimeServices(PullConnectorsService pullConnectorsService, StreamConnectorsService streamConnectorsService)
        {
            _pullConnectorsService = pullConnectorsService;
            _streamConnectorsService = streamConnectorsService;
        }

        /// <inheritdoc/>
        public ServiceAspect Aspect => "TimeSeries";

        /// <inheritdoc/>
        public IEnumerable<Service> BindServices()
        {
            return new Service[] {
                new Service(_pullConnectorsService, grpc.PullConnectors.BindService(_pullConnectorsService), grpc.PullConnectors.Descriptor),
                new Service(_streamConnectorsService, grpc.StreamConnectors.BindService(_streamConnectorsService), grpc.StreamConnectors.Descriptor)
            };
        }
    }
}